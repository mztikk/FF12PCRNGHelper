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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.tbGridSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearchDepth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbPatchAutoPause = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.label1.Size = new System.Drawing.Size(137, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refresh Interval:";
            this.toolTip1.SetToolTip(this.label1, "Time in milliseconds between refreshing.");
            // 
            // tbInterval
            // 
            this.tbInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.tbInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInterval.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbInterval.ForeColor = System.Drawing.Color.White;
            this.tbInterval.Location = new System.Drawing.Point(0, 37);
            this.tbInterval.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(473, 31);
            this.tbInterval.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbInterval, "Time in milliseconds between refreshing.");
            this.tbInterval.Validating += new System.ComponentModel.CancelEventHandler(this.TbInterval_Validating);
            // 
            // tbGridSize
            // 
            this.tbGridSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.tbGridSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGridSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbGridSize.ForeColor = System.Drawing.Color.White;
            this.tbGridSize.Location = new System.Drawing.Point(0, 105);
            this.tbGridSize.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.tbGridSize.Name = "tbGridSize";
            this.tbGridSize.Size = new System.Drawing.Size(473, 31);
            this.tbGridSize.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tbGridSize, "Amount of items displayed in the grid.");
            this.tbGridSize.Validating += new System.ComponentModel.CancelEventHandler(this.TbGridSize_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.label2.Size = new System.Drawing.Size(78, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gridsize:";
            this.toolTip1.SetToolTip(this.label2, "Amount of items displayed in the grid.");
            // 
            // tbSearchDepth
            // 
            this.tbSearchDepth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.tbSearchDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearchDepth.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSearchDepth.ForeColor = System.Drawing.Color.White;
            this.tbSearchDepth.Location = new System.Drawing.Point(0, 173);
            this.tbSearchDepth.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.tbSearchDepth.Name = "tbSearchDepth";
            this.tbSearchDepth.Size = new System.Drawing.Size(473, 31);
            this.tbSearchDepth.TabIndex = 5;
            this.toolTip1.SetToolTip(this.tbSearchDepth, "Amount of random numbers to search through, if you set this too high it will lag " +
        "on searching.");
            this.tbSearchDepth.Validating += new System.ComponentModel.CancelEventHandler(this.TbSearchDepth_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.label3.Size = new System.Drawing.Size(120, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search depth:";
            this.toolTip1.SetToolTip(this.label3, "Amount of random numbers to search through, if you set this too high it will lag " +
        "on searching.");
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(214)))));
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(0, 355);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(473, 52);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(214)))));
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(0, 303);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(473, 52);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 500000;
            this.toolTip1.InitialDelay = 250;
            this.toolTip1.ReshowDelay = 50;
            // 
            // cbPatchAutoPause
            // 
            this.cbPatchAutoPause.AutoSize = true;
            this.cbPatchAutoPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPatchAutoPause.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPatchAutoPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPatchAutoPause.ForeColor = System.Drawing.Color.White;
            this.cbPatchAutoPause.Location = new System.Drawing.Point(0, 204);
            this.cbPatchAutoPause.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.cbPatchAutoPause.Name = "cbPatchAutoPause";
            this.cbPatchAutoPause.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.cbPatchAutoPause.Size = new System.Drawing.Size(473, 39);
            this.cbPatchAutoPause.TabIndex = 10;
            this.cbPatchAutoPause.Text = "Patch Auto Pause";
            this.toolTip1.SetToolTip(this.cbPatchAutoPause, "Patch the auto pause function call. Enable to disable auto pause and vice versa.");
            this.cbPatchAutoPause.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(473, 407);
            this.Controls.Add(this.cbPatchAutoPause);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.tbSearchDepth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbGridSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbInterval);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MinimumSize = new System.Drawing.Size(485, 429);
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
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbPatchAutoPause;
    }
}