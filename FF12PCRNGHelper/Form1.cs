using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using FF12PCRNGHelper.Patching;
using RFDown.Windows.Memory.Exceptions;

namespace FF12PCRNGHelper
{
    public partial class Form1 : Form
    {
        public enum CompareType : byte
        {
            Equal,

            LesserOrEqual,

            GreaterOrEqual
        }

        public enum StealType : byte
        {
            None,

            Common,

            Uncommon,

            Rare
        }

        internal static ZodiacMemory ZodiacMemory;

        private static Color _defaultBackColor;

        private static Color _defaultBackHighColor;

        private static readonly Color HighlightBackColor = Color.Green;

        private static readonly Color SelectionHighlightBackColor = Color.DarkGreen;

        internal static BytePatch AutoPause = new AutoPause();

        private readonly RNG2002 _rng = new RNG2002();

        private int _foundIndex = -1;

        private bool _lock;

        private int _movement;

        private uint[] _rngDump;

        private RngInjectionForm _rngInjectionForm;

        private uint[][] _rVals = new uint[10][];

        public Form1()
        {
            InitializeComponent();
            tbSearch_Leave(null, null);
            //this.dataGridView1.Rows.Add();
            // Add check if ppl had higher size before this update to set it down for compatibility to avoid crashes.
            // Since we're caching 10 random values, max grid size is 2 * 624 - 10
            if (Config.GridSize > 1238)
            {
                Config.GridSize = 1238;
            }

            dataGridView2.Rows.Add(Config.GridSize);

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridView2,
                new object[] { true });

            _defaultBackColor = dataGridView2.DefaultCellStyle.BackColor;
            _defaultBackHighColor = dataGridView2.DefaultCellStyle.SelectionBackColor;

            timer1.Interval = Config.RefreshInterval;
            timer1.Start();
        }

        // TODO: Make searching better so it only generates the amount of random numbers needed for the current search and gets new every iteration instead of just dumping the whole thing.
        private int SearchPercentages(PSearch[] percentages)
        {
            try
            {
                var rng = new RNG2002();
                (uint[] mt, int mti) = ZodiacMemory.GetMtAndMti(MemoryData.MtAddress);

                rng.LoadState(mti, in mt);
                _rngDump = rng.Dump(Config.SearchDepth);

                for (int i = 0; i < _rngDump.Length; i++)
                {
                    uint pVal = _rngDump[i] % 100;
                    switch (percentages[0].CompareType)
                    {
                        case CompareType.Equal:
                            if (pVal != percentages[0].Percentage)
                            {
                                continue;
                            }

                            break;
                        case CompareType.LesserOrEqual:
                            if (pVal > percentages[0].Percentage)
                            {
                                continue;
                            }

                            break;
                        case CompareType.GreaterOrEqual:
                            if (pVal < percentages[0].Percentage)
                            {
                                continue;
                            }

                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    if (SearchDump(percentages, i))
                    {
                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is OutOfMemoryException)
                {
                    MessageBox.Show("Ran out of memory, lower your search depth.");
                }
            }
            finally
            {
                _rngDump = Array.Empty<uint>();
            }

            return -1;
        }

        private bool SearchDump(PSearch[] percentages, int index)
        {
            for (int i = 0; i < percentages.Length; i++)
            {
                uint pVal = _rngDump[index + i] % 100;
                switch (percentages[i].CompareType)
                {
                    case CompareType.Equal:
                        if (pVal != percentages[i].Percentage)
                        {
                            return false;
                        }

                        break;
                    case CompareType.LesserOrEqual:
                        if (pVal > percentages[i].Percentage)
                        {
                            return false;
                        }

                        break;
                    case CompareType.GreaterOrEqual:
                        if (pVal < percentages[i].Percentage)
                        {
                            return false;
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return true;
        }

        private bool AttachProc()
        {
            if (ZodiacMemory != null)
            {
                return false;
            }

            Process[] procs = Process.GetProcessesByName("FFXII_TZA");
            if (!procs.Any())
            {
                return false;
            }

            Process proc = procs.Single();
            if (proc.HasExited)
            {
                return false;
            }

            ZodiacMemory = new ZodiacMemory(proc);
            return true;
        }

        private static StealType GetStealType(uint rVal1, uint rVal2, uint rVal3)
        {
            if (rVal1 % 100 < 3)
            {
                return StealType.Rare;
            }

            if (rVal2 % 100 < 10)
            {
                return StealType.Uncommon;
            }

            if (rVal3 % 100 < 55)
            {
                return StealType.Common;
            }

            return StealType.None;
        }

        private static List<StealType> GetStealTypeCuffs(uint rVal1, uint rVal2, uint rVal3)
        {
            var rtn = new List<StealType>();
            if (rVal1 % 100 < 6)
            {
                rtn.Add(StealType.Rare);
            }

            if (rVal2 % 100 < 30)
            {
                rtn.Add(StealType.Uncommon);
            }

            if (rVal3 % 100 < 80)
            {
                rtn.Add(StealType.Common);
            }

            if (!rtn.Any())
            {
                rtn.Add(StealType.None);
            }

            return rtn;
        }

        private void Generate(bool forceRefresh = false)
        {
            if (_foundIndex == 0)
            {
                stepsToResult.Text = "You are at your search result!";
            }
            else if (_foundIndex > 0)
            {
                stepsToResult.Text = "Advances to search result: " + _foundIndex;
            }
            else
            {
                stepsToResult.Text = string.Empty;
            }

            if (_movement == 0 && !forceRefresh)
            {
                return;
            }

            for (int i = 0; i < _rVals.Length; i++)
            {
                RNG2002.RNGState p = _rng.Peek(i);
                _rVals[i] = new[] { p.value, (uint)p.mti, p.mt };
            }

            uint level = (uint)numericLevel.Value;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = i;
                dataGridView2.Rows[i].Cells[1].Value = _rVals[0][0] % 100;
                dataGridView2.Rows[i].Cells[2].Value = _rVals[0][0] < 0x1000000;
                dataGridView2.Rows[i].Cells[3].Value =
                    GetStealType(_rVals[0][0], _rVals[1][0], _rVals[2][0]);
                dataGridView2.Rows[i].Cells[4].Value = string.Join(" + ",
                    GetStealTypeCuffs(_rVals[0][0], _rVals[1][0], _rVals[2][0]));

                int pAmount = LevelUpStats.PerfectHpMpCount(level, ref _rVals);
                string pString;
                if (pAmount <= 0)
                {
                    pString = "False";
                }
                else if (pAmount == 1)
                {
                    pString = "True";
                }
                else
                {
                    pString = "True " + pAmount;
                }

                dataGridView2.Rows[i].Cells[5].Value = pString;
                dataGridView2.Rows[i].Cells[6].Value =
                    numericGil.Value == 0 ? 0 : 1 + _rVals[0][0] % numericGil.Value;
                dataGridView2.Rows[i].Cells[7].Value = _rVals[0][0];
                dataGridView2.Rows[i].Cells[8].Value = _rVals[0][1];
                dataGridView2.Rows[i].Cells[9].Value = _rVals[0][2];
                if (i == _foundIndex)
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = _defaultBackColor;
                    dataGridView2.Rows[i].DefaultCellStyle.SelectionBackColor = _defaultBackHighColor;

                    if (_movement <= i)
                    {
                        dataGridView2.Rows[i - _movement].DefaultCellStyle.BackColor = HighlightBackColor;
                        dataGridView2.Rows[i - _movement].DefaultCellStyle.SelectionBackColor =
                            SelectionHighlightBackColor;
                    }
                }

                Array.Copy(_rVals, 1, _rVals, 0, _rVals.Length - 1);
                RNG2002.RNGState p = _rng.Peek(_rVals.Length + i);
                _rVals[_rVals.Length - 1] = new[] { p.value, (uint)p.mti, p.mt };
            }

            if (_foundIndex > -1)
            {
                _foundIndex -= _movement;
            }
            else
            {
                _foundIndex = -1;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (_lock)
            {
                return;
            }

            if (ZodiacMemory == null)
            {
                if (AttachProc())
                {
                    if (Config.PatchAutoPause)
                    {
                        AutoPause.Apply();
                    }
                }
            }
            else
            {
                try
                {
                    (uint[] mt, int mti) = ZodiacMemory.GetMtAndMti(MemoryData.MtAddress);

                    _movement = _rng.Sync(mti, in mt);

                    // On load or rng injection, reload and reset.
                    if (_movement == -1)
                    {
                        _rng.LoadState(mti, in mt);
                        ResetGridHighlighting();
                    }

                    Generate();
                }
                // Couldn't read from process, so we dispose.
                catch (ReadMemoryException)
                {
                    ZodiacMemory.Dispose();
                    ZodiacMemory = null;
                }
            }
        }

        private void ForceUpdate()
        {
            if (ZodiacMemory == null)
            {
                return;
            }

            try
            {
                _movement = -1;
                (uint[] mt, int mti) = ZodiacMemory.GetMtAndMti(MemoryData.MtAddress);
                _rng.LoadState(mti, in mt);
                Generate();
            }
            // Couldn't read from process, so we dispose.
            catch (Win32Exception)
            {
                ZodiacMemory.Dispose();
                ZodiacMemory = null;
            }
        }

        /*
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this._lock)
            {
                return;
            }

            this._lock = true;
            if (RemoteMem == null)
            {
                AttachProc();
            }
            else
            {
                try
                {
                    this.Generate();
                }
                catch
                {
                    RemoteMem.Dispose();
                    RemoteMem = null;
                }
            }

            this._lock = false;
            
        }
        */

        private void ResetGridHighlighting()
        {
            if (_foundIndex > -1)
            {
                if (_foundIndex < dataGridView2.RowCount)
                {
                    dataGridView2.Rows[_foundIndex].DefaultCellStyle.BackColor = _defaultBackColor;
                    dataGridView2.Rows[_foundIndex].DefaultCellStyle.SelectionBackColor =
                        _defaultBackHighColor;
                }

                _foundIndex = -1;
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            ResetGridHighlighting();

            string t = Strings.RemoveWhitespace(tbSearch.Text);
            if (t.Except("1234567890+-,").Any())
            {
                return;
            }

            string[] vals = t.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var parsed = new PSearch[vals.Length];
            for (int i = 0; i < vals.Length; i++)
            {
                CompareType cType;
                if (vals[i].Contains('+'))
                {
                    cType = CompareType.GreaterOrEqual;
                }
                else if (vals[i].Contains('-'))
                {
                    cType = CompareType.LesserOrEqual;
                }
                else
                {
                    cType = CompareType.Equal;
                }

                string cl = vals[i].Replace("+", string.Empty).Replace("-", string.Empty);
                if (!uint.TryParse(cl, out uint tmp))
                {
                    return;
                }

                parsed[i] = new PSearch(tmp, cType);
            }

            if (!parsed.Any())
            {
                return;
            }

            _foundIndex = SearchPercentages(parsed);
            if (_foundIndex == -1)
            {
                MessageBox.Show("Entered percentage(s) not found.");
            }
            else if (_foundIndex < dataGridView2.RowCount)
            {
                dataGridView2.Rows[_foundIndex].DefaultCellStyle.BackColor = HighlightBackColor;
                dataGridView2.Rows[_foundIndex].DefaultCellStyle.SelectionBackColor =
                    SelectionHighlightBackColor;
                dataGridView2.FirstDisplayedScrollingRowIndex = _foundIndex;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => Config.Save();

        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            var cfg = new ConfigForm(ref timer1);
            if (cfg.ShowDialog(this) == DialogResult.OK)
            {
                if (dataGridView2.RowCount != Config.GridSize)
                {
                    dataGridView2.Rows.Clear();
                    dataGridView2.Rows.Add(Config.GridSize);
                    ForceUpdate();
                }
            }
        }

        private void DataGridView2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)
            {
                ButtonGridDump_Click(dataGridView2, new EventArgs());
            }
        }

        private void ButtonGridDump_Click(object sender, EventArgs e)
        {
            var d = new DumpForm(dataGridView2.SelectedRows, dataGridView2.Columns);
            d.Show(this);
        }

        private void Button3Search_Click(object sender, EventArgs e) => SearchPerfectLevels(3);

        private void Button20002Search_Click(object sender, EventArgs e) => DynamicSearchRngDump(() =>
                                                                          {
                                                                              bool first = true;
                                                                              for (int i = 0; i < _rngDump.Length - 5; i++)
                                                                              {
                                                                                  if (first)
                                                                                  {
                                                                                      if (LevelUpStats.PerfectHpMpCount((uint)numericLevel.Value, ref _rngDump, i) >= 2)
                                                                                      {
                                                                                          first = false;
                                                                                          i += 3;
                                                                                      }
                                                                                  }
                                                                                  else
                                                                                  {
                                                                                      if (LevelUpStats.PerfectHpMpCount((uint)numericLevel.Value, ref _rngDump, i) >= 2)
                                                                                      {
                                                                                          _foundIndex = i - 4;
                                                                                          break;
                                                                                      }

                                                                                      i -= 3;
                                                                                      first = true;
                                                                                  }
                                                                              }
                                                                          });

        private void SearchMenuHighestPerfect_Click(object sender, EventArgs e) => DynamicSearchRngDump(() =>
                                                                                 {
                                                                                     int highest = 0;
                                                                                     int highestIndex = -1;
                                                                                     for (int i = 0; i < _rngDump.Length; i++)
                                                                                     {
                                                                                         int pAmount = LevelUpStats.PerfectHpMpCount((uint)numericLevel.Value, ref _rngDump, i);
                                                                                         if (pAmount > highest)
                                                                                         {
                                                                                             highest = pAmount;
                                                                                             highestIndex = i;
                                                                                         }
                                                                                     }

                                                                                     _foundIndex = highestIndex;
                                                                                 });

        private void SearchPerfectLevels(int minLevel) => DynamicSearchRngDump(() =>
                                                        {
                                                            for (int i = 0; i < _rngDump.Length - minLevel; i++)
                                                            {
                                                                if (LevelUpStats.PerfectHpMpCount((uint)numericLevel.Value, ref _rngDump, i) >= minLevel)
                                                                {
                                                                    _foundIndex = i;
                                                                    break;
                                                                }
                                                            }
                                                        });

        private void SearchMenu1Search_Click(object sender, EventArgs e) => SearchPerfectLevels(1);

        private void DynamicSearchRngDump(Action action)
        {
            ResetGridHighlighting();

            try
            {
                var rng = new RNG2002();
                (uint[] mt, int mti) = ZodiacMemory.GetMtAndMti(MemoryData.MtAddress);

                rng.LoadState(mti, in mt);
                _rngDump = rng.Dump(Config.SearchDepth);

                action.Invoke();
            }
            catch (Exception ex)
            {
                if (ex is OutOfMemoryException)
                {
                    MessageBox.Show("Ran out of memory, lower your search depth.");
                }
            }
            finally
            {
                _rngDump = Array.Empty<uint>();
                if (_foundIndex < 0)
                {
                    MessageBox.Show("Nothing found.");
                }
                else if (_foundIndex < dataGridView2.RowCount)
                {
                    dataGridView2.Rows[_foundIndex].DefaultCellStyle.BackColor = HighlightBackColor;
                    dataGridView2.Rows[_foundIndex].DefaultCellStyle.SelectionBackColor =
                        SelectionHighlightBackColor;
                    dataGridView2.FirstDisplayedScrollingRowIndex = _foundIndex;
                }
            }
        }

        private void SearchMenu1256_Click(object sender, EventArgs e) => DynamicSearchRngDump(() =>
                                                                       {
                                                                           for (int i = 0; i < _rngDump.Length; i++)
                                                                           {
                                                                               if (_rngDump[i] < 0x1000000)
                                                                               {
                                                                                   _foundIndex = i;
                                                                                   break;
                                                                               }
                                                                           }
                                                                       });

        private void ButtonRngInjection_Click(object sender, EventArgs e)
        {
            if (!RngInjectionForm.IsOpen)
            {
                _rngInjectionForm = new RngInjectionForm(ref dataGridView2);
                _rngInjectionForm.Show(this);
            }
            else
            {
                if (_rngInjectionForm?.WindowState == FormWindowState.Minimized)
                {
                    _rngInjectionForm.WindowState = FormWindowState.Normal;
                }

                _rngInjectionForm?.Activate();
            }
        }

        private void Numeric_ValueChanged(object sender, EventArgs e) => Generate(true);

        public struct PSearch
        {
            public uint Percentage { get; }

            public CompareType CompareType { get; }

            public PSearch(uint percentage, CompareType compareType)
            {
                Percentage = percentage;
                CompareType = compareType;
            }
        }

        private const string tbSearchPlaceholder = "Percentage search";

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text == tbSearchPlaceholder)
            {
                tbSearch.Text = "";
                tbSearch.ForeColor = Color.White;
            }
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text.Trim() == "")
            {
                tbSearch.Text = tbSearchPlaceholder;
                tbSearch.ForeColor = Color.FromArgb(142, 142, 147);
            }
        }
    }
}
