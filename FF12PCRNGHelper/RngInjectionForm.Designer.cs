namespace FF12PCRNGHelper
{
    partial class RngInjectionForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonInject = new System.Windows.Forms.Button();
            this.buttonInjectClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonDirectInject = new System.Windows.Forms.Button();
            this.numericRepeat = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericIndex = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonMti = new System.Windows.Forms.RadioButton();
            this.radioButtonGrid = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonMt = new System.Windows.Forms.RadioButton();
            this.radioButtonValue = new System.Windows.Forms.RadioButton();
            this.radioButtonPercentage = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numericValue = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRepeat)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIndex)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 345F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 345F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 345F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 345);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonInject, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonInjectClear, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(395, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(163, 339);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(157, 265);
            this.textBox1.TabIndex = 10;
            this.textBox1.Enter += new System.EventHandler(this.TextBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // buttonInject
            // 
            this.buttonInject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInject.Location = new System.Drawing.Point(3, 274);
            this.buttonInject.Name = "buttonInject";
            this.buttonInject.Size = new System.Drawing.Size(157, 27);
            this.buttonInject.TabIndex = 11;
            this.buttonInject.Text = "Inject RNG";
            this.buttonInject.UseVisualStyleBackColor = true;
            this.buttonInject.Click += new System.EventHandler(this.ButtonInject_Click);
            // 
            // buttonInjectClear
            // 
            this.buttonInjectClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInjectClear.Location = new System.Drawing.Point(3, 307);
            this.buttonInjectClear.Name = "buttonInjectClear";
            this.buttonInjectClear.Size = new System.Drawing.Size(157, 29);
            this.buttonInjectClear.TabIndex = 12;
            this.buttonInjectClear.Text = "Clear";
            this.buttonInjectClear.UseVisualStyleBackColor = true;
            this.buttonInjectClear.Click += new System.EventHandler(this.ButtonInjectClear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 339);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::FF12PCRNGHelper.Properties.Resources.image_loading;
            this.pictureBox1.Location = new System.Drawing.Point(333, 286);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonDirectInject);
            this.panel4.Controls.Add(this.numericRepeat);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.buttonAdd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 157);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 123);
            this.panel4.TabIndex = 18;
            // 
            // buttonDirectInject
            // 
            this.buttonDirectInject.Location = new System.Drawing.Point(3, 80);
            this.buttonDirectInject.Name = "buttonDirectInject";
            this.buttonDirectInject.Size = new System.Drawing.Size(75, 23);
            this.buttonDirectInject.TabIndex = 9;
            this.buttonDirectInject.Text = "Inject Directly";
            this.buttonDirectInject.UseVisualStyleBackColor = true;
            this.buttonDirectInject.Click += new System.EventHandler(this.ButtonDirectInject_Click);
            // 
            // numericRepeat
            // 
            this.numericRepeat.Location = new System.Drawing.Point(3, 25);
            this.numericRepeat.Maximum = new decimal(new int[] {
            624,
            0,
            0,
            0});
            this.numericRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRepeat.Name = "numericRepeat";
            this.numericRepeat.Size = new System.Drawing.Size(120, 20);
            this.numericRepeat.TabIndex = 7;
            this.numericRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Repeat";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(3, 51);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericIndex);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.radioButtonMti);
            this.panel2.Controls.Add(this.radioButtonGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 83);
            this.panel2.TabIndex = 17;
            // 
            // numericIndex
            // 
            this.numericIndex.Location = new System.Drawing.Point(3, 48);
            this.numericIndex.Name = "numericIndex";
            this.numericIndex.Size = new System.Drawing.Size(120, 20);
            this.numericIndex.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Index";
            // 
            // radioButtonMti
            // 
            this.radioButtonMti.AutoSize = true;
            this.radioButtonMti.Location = new System.Drawing.Point(79, 25);
            this.radioButtonMti.Name = "radioButtonMti";
            this.radioButtonMti.Size = new System.Drawing.Size(44, 17);
            this.radioButtonMti.TabIndex = 5;
            this.radioButtonMti.Text = "MTI";
            this.radioButtonMti.UseVisualStyleBackColor = true;
            // 
            // radioButtonGrid
            // 
            this.radioButtonGrid.AutoSize = true;
            this.radioButtonGrid.Checked = true;
            this.radioButtonGrid.Location = new System.Drawing.Point(3, 25);
            this.radioButtonGrid.Name = "radioButtonGrid";
            this.radioButtonGrid.Size = new System.Drawing.Size(70, 17);
            this.radioButtonGrid.TabIndex = 4;
            this.radioButtonGrid.TabStop = true;
            this.radioButtonGrid.Text = "GridIndex";
            this.radioButtonGrid.UseVisualStyleBackColor = true;
            this.radioButtonGrid.CheckedChanged += new System.EventHandler(this.RadioButtonGrid_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButtonMt);
            this.panel3.Controls.Add(this.radioButtonValue);
            this.panel3.Controls.Add(this.radioButtonPercentage);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.numericValue);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 74);
            this.panel3.TabIndex = 16;
            // 
            // radioButtonMt
            // 
            this.radioButtonMt.AutoSize = true;
            this.radioButtonMt.Location = new System.Drawing.Point(147, 21);
            this.radioButtonMt.Name = "radioButtonMt";
            this.radioButtonMt.Size = new System.Drawing.Size(41, 17);
            this.radioButtonMt.TabIndex = 2;
            this.radioButtonMt.TabStop = true;
            this.radioButtonMt.Text = "MT";
            this.radioButtonMt.UseVisualStyleBackColor = true;
            // 
            // radioButtonValue
            // 
            this.radioButtonValue.AutoSize = true;
            this.radioButtonValue.Location = new System.Drawing.Point(89, 21);
            this.radioButtonValue.Name = "radioButtonValue";
            this.radioButtonValue.Size = new System.Drawing.Size(52, 17);
            this.radioButtonValue.TabIndex = 1;
            this.radioButtonValue.Text = "Value";
            this.radioButtonValue.UseVisualStyleBackColor = true;
            // 
            // radioButtonPercentage
            // 
            this.radioButtonPercentage.AutoSize = true;
            this.radioButtonPercentage.Checked = true;
            this.radioButtonPercentage.Location = new System.Drawing.Point(3, 21);
            this.radioButtonPercentage.Name = "radioButtonPercentage";
            this.radioButtonPercentage.Size = new System.Drawing.Size(80, 17);
            this.radioButtonPercentage.TabIndex = 0;
            this.radioButtonPercentage.TabStop = true;
            this.radioButtonPercentage.Text = "Percentage";
            this.radioButtonPercentage.UseVisualStyleBackColor = true;
            this.radioButtonPercentage.CheckedChanged += new System.EventHandler(this.RadioButtonPercentage_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Value";
            // 
            // numericValue
            // 
            this.numericValue.Location = new System.Drawing.Point(3, 44);
            this.numericValue.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericValue.Name = "numericValue";
            this.numericValue.Size = new System.Drawing.Size(120, 20);
            this.numericValue.TabIndex = 3;
            // 
            // RngInjectionForm
            // 
            this.AcceptButton = this.buttonDirectInject;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 345);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RngInjectionForm";
            this.Text = "RNG Injection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RngInjectionForm_FormClosing);
            this.Load += new System.EventHandler(this.RngInjectionForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRepeat)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIndex)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonInject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButtonPercentage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericValue;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.NumericUpDown numericRepeat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonMti;
        private System.Windows.Forms.RadioButton radioButtonGrid;
        private System.Windows.Forms.RadioButton radioButtonMt;
        private System.Windows.Forms.RadioButton radioButtonValue;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonInjectClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDirectInject;
    }
}