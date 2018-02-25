using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FF12PCRNGHelper
{
    public partial class Form1 : Form
    {
        public enum StealType
        {
            None,

            Common,

            Uncommon,

            Rare
        }

        private static RemoteMemory _remoteMem;

        private readonly int _gridSize = 1000;

        private readonly uint[][] _rVals = new uint[10][];

        public Form1()
        {
            this.InitializeComponent();
            this.timer1.Start();

            this.dataGridView1.Rows.Add();
            this.dataGridView2.Rows.Add(this._gridSize);
        }

        private static void AttachProc()
        {
            if (_remoteMem != null)
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

            _remoteMem = new RemoteMemory(proc);
        }

        private static bool RemoteInvalid()
        {
            return _remoteMem == null || !_remoteMem.IsValid;
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

        private void Generate()
        {
            if (RemoteInvalid())
            {
                return;
            }

            var mti = _remoteMem.Read<int>(MemoryData.MtiAddress, true);
            var mt = _remoteMem.Read<uint>(MemoryData.MtAddress, 624, true);

            var rng = new RNG2002();
            rng.loadState(mti, mt);

            for (var i = 0; i < this._rVals.Length; i++)
            {
                this._rVals[i] = new[] {rng.genrand(), (uint) rng.mti, rng.mt[rng.mti - 1]};
            }

            this.dataGridView1.Rows[0].Cells[0].Value = 0;
            this.dataGridView1.Rows[0].Cells[1].Value = this._rVals[0][0] % 100;
            this.dataGridView1.Rows[0].Cells[2].Value = this._rVals[0][0] < 0x1000000;
            this.dataGridView1.Rows[0].Cells[3].Value =
                GetStealType(this._rVals[0][0], this._rVals[1][0], this._rVals[2][0]);
            this.dataGridView1.Rows[0].Cells[4].Value = string.Join(" + ",
                GetStealTypeCuffs(this._rVals[0][0], this._rVals[1][0], this._rVals[2][0]));
            this.dataGridView1.Rows[0].Cells[5].Value = this._rVals[0][0];
            this.dataGridView1.Rows[0].Cells[6].Value = this._rVals[0][1];
            this.dataGridView1.Rows[0].Cells[7].Value = this._rVals[0][2];

            for (var i = 1; i <= this._gridSize; i++)
            {
                Array.Copy(this._rVals, 1, this._rVals, 0, this._rVals.Length - 1);
                this._rVals[this._rVals.Length - 1] = new[] {rng.genrand(), (uint) rng.mti, rng.mt[rng.mti - 1]};

                this.dataGridView2.Rows[i - 1].Cells[0].Value = i;
                this.dataGridView2.Rows[i - 1].Cells[1].Value = this._rVals[0][0] % 100;
                this.dataGridView2.Rows[i - 1].Cells[2].Value = this._rVals[0][0] < 0x1000000;
                this.dataGridView2.Rows[i - 1].Cells[3].Value =
                    GetStealType(this._rVals[0][0], this._rVals[1][0], this._rVals[2][0]);
                this.dataGridView2.Rows[i - 1].Cells[4].Value = string.Join(" + ",
                    GetStealTypeCuffs(this._rVals[0][0], this._rVals[1][0], this._rVals[2][0]));
                this.dataGridView2.Rows[i - 1].Cells[5].Value = this._rVals[0][0];
                this.dataGridView2.Rows[i - 1].Cells[6].Value = this._rVals[0][1];
                this.dataGridView2.Rows[i - 1].Cells[7].Value = this._rVals[0][2];
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (_remoteMem == null)
            {
                AttachProc();
            }
            else if (RemoteInvalid())
            {
                _remoteMem.Dispose();
                _remoteMem = null;
            }
            else
            {
                this.Generate();
            }
        }

        private void TbInterval_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(this.tbInterval.Text, out var tmp))
            {
                this.tbInterval.Text = "100";
                tmp = 100;
            }

            if (tmp < 1)
            {
                tmp = 1;
                this.tbInterval.Text = "1";
            }

            this.timer1.Interval = tmp;
        }

        private void TbInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                this.tbInterval.FindForm()?.Validate();
                e.Handled = true;
            }
        }
    }
}