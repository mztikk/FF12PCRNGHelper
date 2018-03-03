namespace FF12PCRNGHelper
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.tbGridSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearchDepth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbWorkerAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refresh Interval:";
            this.toolTip1.SetToolTip(this.label1, "Time in milliseconds between refreshing.");
            // 
            // tbInterval
            // 
            this.tbInterval.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbInterval.Location = new System.Drawing.Point(0, 18);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(284, 20);
            this.tbInterval.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbInterval, "Time in milliseconds between refreshing.");
            this.tbInterval.Validating += new System.ComponentModel.CancelEventHandler(this.TbInterval_Validating);
            // 
            // tbGridSize
            // 
            this.tbGridSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbGridSize.Location = new System.Drawing.Point(0, 56);
            this.tbGridSize.Name = "tbGridSize";
            this.tbGridSize.Size = new System.Drawing.Size(284, 20);
            this.tbGridSize.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tbGridSize, "Amount of items displayed in the grid.");
            this.tbGridSize.Validating += new System.ComponentModel.CancelEventHandler(this.TbGridSize_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 38);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gridsize:";
            this.toolTip1.SetToolTip(this.label2, "Amount of items displayed in the grid.");
            // 
            // tbSearchDepth
            // 
            this.tbSearchDepth.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSearchDepth.Location = new System.Drawing.Point(0, 94);
            this.tbSearchDepth.Name = "tbSearchDepth";
            this.tbSearchDepth.Size = new System.Drawing.Size(284, 20);
            this.tbSearchDepth.TabIndex = 5;
            this.toolTip1.SetToolTip(this.tbSearchDepth, "Amount of random numbers to search through, if you set this too high it will lag " +
        "on searching.");
            this.tbSearchDepth.Validating += new System.ComponentModel.CancelEventHandler(this.TbSearchDepth_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 76);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search depth:";
            this.toolTip1.SetToolTip(this.label3, "Amount of random numbers to search through, if you set this too high it will lag " +
        "on searching.");
            // 
            // tbWorkerAmount
            // 
            this.tbWorkerAmount.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbWorkerAmount.Location = new System.Drawing.Point(0, 132);
            this.tbWorkerAmount.Name = "tbWorkerAmount";
            this.tbWorkerAmount.Size = new System.Drawing.Size(284, 20);
            this.tbWorkerAmount.TabIndex = 7;
            this.toolTip1.SetToolTip(this.tbWorkerAmount, "Amount of workers used to find matching mt values. (Not implemented yet.)");
            this.tbWorkerAmount.Visible = false;
            this.tbWorkerAmount.Validating += new System.ComponentModel.CancelEventHandler(this.TbWorkerAmount_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 114);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Worker amount:";
            this.toolTip1.SetToolTip(this.label4, "Amount of workers used to find matching mt values. (Not implemented yet.)");
            this.label4.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSave.Location = new System.Drawing.Point(0, 188);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(284, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCancel.Location = new System.Drawing.Point(0, 165);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(284, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 500000;
            this.toolTip1.InitialDelay = 250;
            this.toolTip1.ReshowDelay = 50;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.tbWorkerAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSearchDepth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbGridSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbInterval);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(300, 250);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.TextBox tbGridSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearchDepth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbWorkerAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}