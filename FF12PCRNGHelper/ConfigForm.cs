using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FF12PCRNGHelper
{
    public partial class ConfigForm : Form
    {
        private readonly Timer _timer;

        public ConfigForm(ref Timer timer)
        {
            this.InitializeComponent();
            this._timer = timer;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            this.tbInterval.Text = Config.RefreshInterval.ToString();
            this.tbGridSize.Text = Config.GridSize.ToString();
            this.tbSearchDepth.Text = Config.SearchDepth.ToString();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (int.TryParse(this.tbInterval.Text, out var interval) && interval > 0)
            {
                Config.RefreshInterval = interval;
                this._timer.Interval = interval;
            }

            if (int.TryParse(this.tbGridSize.Text, out var gridsize) && gridsize > 0 && gridsize <= 1238)
            {
                Config.GridSize = gridsize;
            }

            if (int.TryParse(this.tbSearchDepth.Text, out var searchDepth) && searchDepth > 0)
            {
                Config.SearchDepth = searchDepth;
            }

            Config.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TbInterval_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(this.tbInterval.Text, out var tmp))
            {
                this.tbInterval.Text = Config.RefreshInterval.ToString();
            }
            else if (tmp < 1)
            {
                this.tbInterval.Text = "1";
            }
        }

        private void TbGridSize_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(this.tbGridSize.Text, out var tmp))
            {
                this.tbGridSize.Text = Config.GridSize.ToString();
            }
            else if (tmp < 1)
            {
                this.tbGridSize.Text = "1";
            }
            else if (tmp > 1238)
            {
                this.tbGridSize.Text = "1238";
            }
        }

        private void TbSearchDepth_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(this.tbSearchDepth.Text, out var tmp))
            {
                this.tbSearchDepth.Text = Config.SearchDepth.ToString();
            }
            else if (tmp < 1)
            {
                this.tbSearchDepth.Text = "1";
            }
        }
    }
}