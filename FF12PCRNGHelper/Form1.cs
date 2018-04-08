using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

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

        internal static RemoteMemory RemoteMem;

        private static Color _defaultBackColor;

        private static Color _defaultBackHighColor;

        private static readonly Color HighlightBackColor = Color.Green;

        private static readonly Color SelectionHighlightBackColor = Color.DarkGreen;

        private readonly RNG2002 _rng = new RNG2002();

        private int _foundIndex = -1;

        private bool _lock;

        private int _movement;

        private uint[] _rngDump;

        private RngInjectionForm _rngInjectionForm;

        private uint[][] _rVals = new uint[10][];

        public Form1()
        {
            this.InitializeComponent();

            //this.dataGridView1.Rows.Add();
            // Add check if ppl had higher size before this update to set it down for compatibility to avoid crashes.
            // Since we're caching 10 random values, max grid size is 2 * 624 - 10
            if (Config.GridSize > 1238)
            {
                Config.GridSize = 1238;
            }

            this.dataGridView2.Rows.Add(Config.GridSize);

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, this.dataGridView2,
                new object[] {true});

            _defaultBackColor = this.dataGridView2.DefaultCellStyle.BackColor;
            _defaultBackHighColor = this.dataGridView2.DefaultCellStyle.SelectionBackColor;

            this.timer1.Interval = Config.RefreshInterval;
            this.timer1.Start();
        }

        // TODO: Make searching better so it only generates the amount of random numbers needed for the current search and gets new every iteration instead of just dumping the whole thing.
        private int SearchPercentages(PSearch[] percentages)
        {
            try
            {
                var rng = new RNG2002();
                var mti = RemoteMem.Read<int>(MemoryData.MtiAddress);
                var mt = RemoteMem.Read<uint>(MemoryData.MtAddress, 624);

                rng.LoadState(mti, in mt);
                this._rngDump = rng.Dump(Config.SearchDepth);

                for (var i = 0; i < this._rngDump.Length; i++)
                {
                    var pVal = this._rngDump[i] % 100;
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

                    if (this.SearchDump(percentages, i))
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
                this._rngDump = Array.Empty<uint>();
            }

            return -1;
        }

        private bool SearchDump(PSearch[] percentages, int index)
        {
            for (var i = 0; i < percentages.Length; i++)
            {
                var pVal = this._rngDump[index + i] % 100;
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

        private void AttachProc()
        {
            if (RemoteMem != null)
            {
                return;
            }

            var procs = Process.GetProcessesByName("FFXII_TZA");
            if (!procs.Any())
            {
                return;
            }

            var proc = procs.Single();
            if (proc.HasExited)
            {
                return;
            }

            RemoteMem = new RemoteMemory(proc);
        }

        // Replaced by try/catch for better performance, handle validity and Process.HasExited calls are costly it seems.
        // Need to look into that some time to maybe optimize it.
        private static bool RemoteInvalid()
        {
            return RemoteMem == null || !RemoteMem.IsValid;
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
            if (this._foundIndex == 0)
            {
                this.stepsToResult.Text = "You are at your search result!";
            }
            else if (this._foundIndex > 0)
            {
                this.stepsToResult.Text = "Advances to search result: " + this._foundIndex;
            }
            else
            {
                this.stepsToResult.Text = string.Empty;
            }

            if (this._movement == 0 && !forceRefresh)
            {
                return;
            }

            for (var i = 0; i < this._rVals.Length; i++)
            {
                var p = this._rng.Peek(i);
                this._rVals[i] = new[] {p.value, (uint) p.mti, p.mt};
            }

            var level = (uint) this.numericLevel.Value;

            for (var i = 0; i < this.dataGridView2.RowCount; i++)
            {
                this.dataGridView2.Rows[i].Cells[0].Value = i;
                this.dataGridView2.Rows[i].Cells[1].Value = this._rVals[0][0] % 100;
                this.dataGridView2.Rows[i].Cells[2].Value = this._rVals[0][0] < 0x1000000;
                this.dataGridView2.Rows[i].Cells[3].Value =
                    GetStealType(this._rVals[0][0], this._rVals[1][0], this._rVals[2][0]);
                this.dataGridView2.Rows[i].Cells[4].Value = string.Join(" + ",
                    GetStealTypeCuffs(this._rVals[0][0], this._rVals[1][0], this._rVals[2][0]));

                var pAmount = LevelUpStats.PerfectHpMpCount(level, ref this._rVals);
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

                this.dataGridView2.Rows[i].Cells[5].Value = pString;
                this.dataGridView2.Rows[i].Cells[6].Value =
                    this.numericGil.Value == 0 ? 0 : 1 + this._rVals[0][0] % this.numericGil.Value;
                this.dataGridView2.Rows[i].Cells[7].Value = this._rVals[0][0];
                this.dataGridView2.Rows[i].Cells[8].Value = this._rVals[0][1];
                this.dataGridView2.Rows[i].Cells[9].Value = this._rVals[0][2];
                if (i == this._foundIndex)
                {
                    this.dataGridView2.Rows[i].DefaultCellStyle.BackColor = _defaultBackColor;
                    this.dataGridView2.Rows[i].DefaultCellStyle.SelectionBackColor = _defaultBackHighColor;

                    if (this._movement <= i)
                    {
                        this.dataGridView2.Rows[i - this._movement].DefaultCellStyle.BackColor = HighlightBackColor;
                        this.dataGridView2.Rows[i - this._movement].DefaultCellStyle.SelectionBackColor =
                            SelectionHighlightBackColor;
                    }
                }

                Array.Copy(this._rVals, 1, this._rVals, 0, this._rVals.Length - 1);
                var p = this._rng.Peek(this._rVals.Length + i);
                this._rVals[this._rVals.Length - 1] = new[] {p.value, (uint) p.mti, p.mt};
            }

            if (this._foundIndex > -1)
            {
                this._foundIndex -= this._movement;
            }
            else
            {
                this._foundIndex = -1;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this._lock)
            {
                return;
            }

            if (RemoteMem == null)
            {
                this.AttachProc();
            }
            else
            {
                try
                {
                    var mti = RemoteMem.Read<int>(MemoryData.MtiAddress);
                    var mt = RemoteMem.Read<uint>(MemoryData.MtAddress, 624);

                    this._movement = this._rng.Sync(mti, in mt);

                    // On load or rng injection, reload and reset.
                    if (this._movement == -1)
                    {
                        this._rng.LoadState(mti, in mt);
                        this.ResetGridHighlighting();
                    }

                    this.Generate();
                }
                // Couldn't read from process, so we dispose.
                catch (Win32Exception)
                {
                    RemoteMem.Dispose();
                    RemoteMem = null;
                }
            }
        }

        private void ForceUpdate()
        {
            if (RemoteMem == null)
            {
                return;
            }

            try
            {
                this._movement = -1;
                var mti = RemoteMem.Read<int>(MemoryData.MtiAddress);
                var mt = RemoteMem.Read<uint>(MemoryData.MtAddress, 624);
                this._rng.LoadState(mti, in mt);
                this.Generate();
            }
            // Couldn't read from process, so we dispose.
            catch (Win32Exception)
            {
                RemoteMem.Dispose();
                RemoteMem = null;
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
            if (this._foundIndex > -1)
            {
                if (this._foundIndex < this.dataGridView2.RowCount)
                {
                    this.dataGridView2.Rows[this._foundIndex].DefaultCellStyle.BackColor = _defaultBackColor;
                    this.dataGridView2.Rows[this._foundIndex].DefaultCellStyle.SelectionBackColor =
                        _defaultBackHighColor;
                }

                this._foundIndex = -1;
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.ResetGridHighlighting();

            var t = Strings.RemoveWhitespace(this.tbSearch.Text);
            if (t.Except("1234567890+-,").Any())
            {
                return;
            }

            var vals = t.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            var parsed = new PSearch[vals.Length];
            for (var i = 0; i < vals.Length; i++)
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

                var cl = vals[i].Replace("+", string.Empty).Replace("-", string.Empty);
                if (!uint.TryParse(cl, out var tmp))
                {
                    return;
                }

                parsed[i] = new PSearch(tmp, cType);
            }

            if (!parsed.Any())
            {
                return;
            }

            this._foundIndex = this.SearchPercentages(parsed);
            if (this._foundIndex == -1)
            {
                MessageBox.Show("Entered percentage(s) not found.");
            }
            else if (this._foundIndex < this.dataGridView2.RowCount)
            {
                this.dataGridView2.Rows[this._foundIndex].DefaultCellStyle.BackColor = HighlightBackColor;
                this.dataGridView2.Rows[this._foundIndex].DefaultCellStyle.SelectionBackColor =
                    SelectionHighlightBackColor;
                this.dataGridView2.FirstDisplayedScrollingRowIndex = this._foundIndex;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Save();
        }

        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            var cfg = new ConfigForm(ref this.timer1);
            if (cfg.ShowDialog(this) == DialogResult.OK)
            {
                if (this.dataGridView2.RowCount != Config.GridSize)
                {
                    this.dataGridView2.Rows.Clear();
                    this.dataGridView2.Rows.Add(Config.GridSize);
                    this.ForceUpdate();
                }
            }
        }

        private void DataGridView2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)
            {
                this.ButtonGridDump_Click(this.dataGridView2, new EventArgs());
            }
        }

        private void ButtonGridDump_Click(object sender, EventArgs e)
        {
            var d = new DumpForm(this.dataGridView2.SelectedRows, this.dataGridView2.Columns);
            d.Show(this);
        }

        private void Button3Search_Click(object sender, EventArgs e)
        {
            this.SearchPerfectLevels(3);
        }

        private void Button20002Search_Click(object sender, EventArgs e)
        {
            this.DynamicSearchRngDump(() =>
            {
                var first = true;
                for (var i = 0; i < this._rngDump.Length - 5; i++)
                {
                    if (first)
                    {
                        if (LevelUpStats.PerfectHpMpCount((uint) this.numericLevel.Value, ref this._rngDump, i) >= 2)
                        {
                            first = false;
                            i += 3;
                        }
                    }
                    else
                    {
                        if (LevelUpStats.PerfectHpMpCount((uint) this.numericLevel.Value, ref this._rngDump, i) >= 2)
                        {
                            this._foundIndex = i - 4;
                            break;
                        }

                        i -= 3;
                        first = true;
                    }
                }
            });
        }

        private void SearchMenuHighestPerfect_Click(object sender, EventArgs e)
        {
            this.DynamicSearchRngDump(() =>
            {
                var highest = 0;
                var highestIndex = -1;
                for (var i = 0; i < this._rngDump.Length; i++)
                {
                    var pAmount = LevelUpStats.PerfectHpMpCount((uint) this.numericLevel.Value, ref this._rngDump, i);
                    if (pAmount > highest)
                    {
                        highest = pAmount;
                        highestIndex = i;
                    }
                }

                this._foundIndex = highestIndex;
            });
        }

        private void SearchPerfectLevels(int minLevel)
        {
            this.DynamicSearchRngDump(() =>
            {
                for (var i = 0; i < this._rngDump.Length - minLevel; i++)
                {
                    if (LevelUpStats.PerfectHpMpCount((uint) this.numericLevel.Value, ref this._rngDump, i) >= minLevel)
                    {
                        this._foundIndex = i;
                        break;
                    }
                }
            });
        }

        private void SearchMenu1Search_Click(object sender, EventArgs e)
        {
            this.SearchPerfectLevels(1);
        }

        private void DynamicSearchRngDump(Action action)
        {
            this.ResetGridHighlighting();

            try
            {
                var rng = new RNG2002();
                var mti = RemoteMem.Read<int>(MemoryData.MtiAddress);
                var mt = RemoteMem.Read<uint>(MemoryData.MtAddress, 624);

                rng.LoadState(mti, in mt);
                this._rngDump = rng.Dump(Config.SearchDepth);

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
                this._rngDump = Array.Empty<uint>();
                if (this._foundIndex < 0)
                {
                    MessageBox.Show("Nothing found.");
                }
                else if (this._foundIndex < this.dataGridView2.RowCount)
                {
                    this.dataGridView2.Rows[this._foundIndex].DefaultCellStyle.BackColor = HighlightBackColor;
                    this.dataGridView2.Rows[this._foundIndex].DefaultCellStyle.SelectionBackColor =
                        SelectionHighlightBackColor;
                    this.dataGridView2.FirstDisplayedScrollingRowIndex = this._foundIndex;
                }
            }
        }

        private void SearchMenu1256_Click(object sender, EventArgs e)
        {
            this.DynamicSearchRngDump(() =>
            {
                for (var i = 0; i < this._rngDump.Length; i++)
                {
                    if (this._rngDump[i] < 0x1000000)
                    {
                        this._foundIndex = i;
                        break;
                    }
                }
            });
        }

        private void ButtonRngInjection_Click(object sender, EventArgs e)
        {
            if (!RngInjectionForm.IsOpen)
            {
                this._rngInjectionForm = new RngInjectionForm(ref this.dataGridView2);
                this._rngInjectionForm.Show(this);
            }
            else
            {
                if (this._rngInjectionForm?.WindowState == FormWindowState.Minimized)
                {
                    this._rngInjectionForm.WindowState = FormWindowState.Normal;
                }

                this._rngInjectionForm?.Activate();
            }
        }

        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            this.Generate(true);
        }

        public struct PSearch
        {
            public uint Percentage { get; }

            public CompareType CompareType { get; }

            public PSearch(uint percentage, CompareType compareType)
            {
                this.Percentage = percentage;
                this.CompareType = compareType;
            }
        }
    }
}