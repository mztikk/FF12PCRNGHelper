using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF12PCRNGHelper
{
    public partial class RngInjectionForm : Form
    {
        public enum IndexType : byte
        {
            GridIndex,

            Mti
        }

        public enum RngType : byte
        {
            Percentage,

            Value,

            Mt
        }

        private readonly DataGridView _dgv;

        public RngInjectionForm(ref DataGridView dgv)
        {
            this._dgv = dgv;
            this.InitializeComponent();

            this.numericIndex.Maximum = Math.Max(Config.GridSize, 624);
        }

        internal static bool IsOpen { get; private set; }

        private void ButtonInject_Click(object sender, EventArgs e)
        {
            var s = this.textBox1.Text.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            var t = new Rng[s.Length];
            for (var i = 0; i < s.Length; i++)
            {
                var v = Strings.RemoveWhitespace(s[i]);
                var vals = v.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                if (vals.Length < 3)
                {
                    return;
                }

                RngType rngType;
                if (vals[0].Contains('%'))
                {
                    rngType = RngType.Percentage;
                }
                else if (vals[0].Contains('v'))
                {
                    rngType = RngType.Value;
                }
                else if (vals[0].Contains('m'))
                {
                    rngType = RngType.Mt;
                }
                else
                {
                    return;
                }

                var valueString = vals[0].Replace("%", string.Empty).Replace("v", string.Empty)
                    .Replace("m", string.Empty);
                if (!uint.TryParse(valueString, out var value))
                {
                    return;
                }

                IndexType indexType;
                if (vals[1].Contains("mti"))
                {
                    indexType = IndexType.Mti;
                }
                else if (vals[1].Contains('i'))
                {
                    indexType = IndexType.GridIndex;
                }
                else
                {
                    return;
                }

                var indexString = vals[1].Replace("mti", string.Empty).Replace("i", string.Empty);
                if (!int.TryParse(indexString, out var index))
                {
                    return;
                }

                if (!vals[2].Contains('r'))
                {
                    return;
                }

                var repeatString = vals[2].Replace("r", string.Empty);
                if (!int.TryParse(repeatString, out var repeat) ||
                    indexType == IndexType.GridIndex && !this.GridIndexValid(index, repeat) ||
                    index + repeat - 1 > 623 && indexType == IndexType.Mti)
                {
                    MessageBox.Show("mti cannot exceed 623");
                    return;
                }

                t[i] = new Rng(rngType, indexType, index, value, repeat);
            }

            if (t.Length <= 0)
            {
                return;
            }

            this.WriteRngAsync(t);
        }

        internal void WriteRng(Rng rng)
        {
            int mti;
            switch (rng.IndexType)
            {
                case IndexType.GridIndex:
                    mti = (int) (uint) this._dgv.Rows[rng.Index].Cells[8].Value;
                    break;
                case IndexType.Mti:
                    mti = rng.Index;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (rng.RngType)
            {
                case RngType.Percentage:
                    RngInjection.WritePercentage(mti, rng.Value, rng.Repeat);
                    break;
                case RngType.Value:
                    RngInjection.WriteValue(mti, rng.Value, rng.Repeat);
                    break;
                case RngType.Mt:
                    RngInjection.WriteMt(mti, rng.Value, rng.Repeat);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var p = (uint) this.numericValue.Value;
            var r = (int) this.numericRepeat.Value;
            var i = (int) this.numericIndex.Value;
            char vSign;
            if (this.radioButtonPercentage.Checked)
            {
                vSign = '%';
            }
            else if (this.radioButtonValue.Checked)
            {
                vSign = 'v';
            }
            else if (this.radioButtonMt.Checked)
            {
                vSign = 'm';
            }
            else
            {
                return;
            }

            string iSign;
            if (this.radioButtonGrid.Checked)
            {
                iSign = "i";
            }
            else if (this.radioButtonMti.Checked)
            {
                iSign = "mti";
            }
            else
            {
                return;
            }

            this.textBox1.AppendText(string.Concat(p, vSign, ", ", i, iSign, ", ", r, "r", Environment.NewLine));
        }

        private bool GridIndexValid(int index, int count = 1)
        {
            if (this._dgv.RowCount <= index || this._dgv.Rows[index].Cells[0].Value == null)
            {
                return false;
            }

            for (var i = 0; i < Math.Min(index + count - 1, this._dgv.RowCount); i++)
            {
                if ((uint) this._dgv.Rows[i].Cells[8].Value == 623)
                {
                    return false;
                }
            }

            return true;
        }

        private void RadioButtonPercentage_CheckedChanged(object sender, EventArgs e)
        {
            this.numericValue.Maximum = this.radioButtonPercentage.Checked ? 99 : uint.MaxValue;
        }

        private void ButtonInjectClear_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
        }

        private void RngInjectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsOpen = false;
        }

        private void RngInjectionForm_Load(object sender, EventArgs e)
        {
            IsOpen = true;
        }

        private void ButtonDirectInject_Click(object sender, EventArgs e)
        {
            RngType rngType;
            if (this.radioButtonPercentage.Checked)
            {
                rngType = RngType.Percentage;
            }
            else if (this.radioButtonValue.Checked)
            {
                rngType = RngType.Value;
            }
            else if (this.radioButtonMt.Checked)
            {
                rngType = RngType.Mt;
            }
            else
            {
                return;
            }

            IndexType indexType;
            if (this.radioButtonGrid.Checked)
            {
                indexType = IndexType.GridIndex;
            }
            else if (this.radioButtonMti.Checked)
            {
                indexType = IndexType.Mti;
            }
            else
            {
                return;
            }

            var i = (int) this.numericIndex.Value;
            var v = (uint) this.numericValue.Value;
            var r = (int) this.numericRepeat.Value;
            if (indexType == IndexType.GridIndex && !this.GridIndexValid(i, r) ||
                indexType == IndexType.Mti && i + r - 1 > 623)
            {
                MessageBox.Show("mti cannot exceed 623");
                return;
            }

            this.WriteRngAsync(new[] {new Rng(rngType, indexType, i, v, r)});
        }

        private async void WriteRngAsync(Rng[] rngToWrite)
        {
            this.buttonInject.Enabled = false;
            this.buttonDirectInject.Enabled = false;
            this.pictureBox1.Enabled = true;
            this.pictureBox1.Visible = true;

            await Task.Run(() =>
            {
                if (rngToWrite.Length > 2)
                {
                    Parallel.ForEach(rngToWrite, this.WriteRng);
                }
                else
                {
                    Array.ForEach(rngToWrite, this.WriteRng);
                }
            });

            this.buttonInject.Enabled = true;
            this.buttonDirectInject.Enabled = true;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Visible = false;
        }

        private void RadioButtonGrid_CheckedChanged(object sender, EventArgs e)
        {
            this.numericIndex.Maximum = this.radioButtonGrid.Checked ? this._dgv.RowCount : 623;
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = this.buttonInject;
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.buttonDirectInject;
        }

        public struct Rng
        {
            public Rng(RngType rngType, IndexType indexType, int index, uint value, int repeat)
            {
                this.RngType = rngType;
                this.IndexType = indexType;
                this.Index = index;
                this.Value = value;
                this.Repeat = repeat;
            }

            public RngType RngType { get; }

            public IndexType IndexType { get; }

            public int Index { get; }

            public uint Value { get; }

            public int Repeat { get; }
        }
    }
}