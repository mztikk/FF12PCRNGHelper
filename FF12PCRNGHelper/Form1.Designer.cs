using System.Windows.Forms;

namespace FF12PCRNGHelper
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonGridDump = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.stepsToResult = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.numericLevel = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.searchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenu20002 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenu3Search = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenu1Search = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenuHighestPerfect = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenu1256 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRngInjection = new System.Windows.Forms.Button();
            this.numericGil = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.gridRightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLevel)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGil)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column2,
            this.Column3,
            this.dataGridViewTextBoxColumn7,
            this.Column9,
            this.Column1});
            this.dataGridView2.ContextMenuStrip = this.gridRightClickMenu;
            this.dataGridView2.Location = new System.Drawing.Point(11, 115);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 30;
            this.dataGridView2.Size = new System.Drawing.Size(665, 336);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGridView2_KeyUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "i";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 32;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "%";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 35;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "1/256?";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Steal";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Steal w/ cuffs";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Perfect HP&MP";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Gil";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 35;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Value";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "mti";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 32;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "mt";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridRightClickMenu
            // 
            this.gridRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonGridDump});
            this.gridRightClickMenu.Name = "gridRightClickMenu";
            this.gridRightClickMenu.Size = new System.Drawing.Size(170, 26);
            // 
            // buttonGridDump
            // 
            this.buttonGridDump.Name = "buttonGridDump";
            this.buttonGridDump.Size = new System.Drawing.Size(169, 22);
            this.buttonGridDump.Text = "Dump (CTRL + Q)";
            this.buttonGridDump.Click += new System.EventHandler(this.ButtonGridDump_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(118, 47);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 12;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // stepsToResult
            // 
            this.stepsToResult.AutoSize = true;
            this.stepsToResult.Location = new System.Drawing.Point(12, 96);
            this.stepsToResult.Name = "stepsToResult";
            this.stepsToResult.Size = new System.Drawing.Size(71, 13);
            this.stepsToResult.TabIndex = 13;
            this.stepsToResult.Text = "SearchResult";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(12, 49);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 20);
            this.tbSearch.TabIndex = 14;
            this.toolTip1.SetToolTip(this.tbSearch, "Enter percentages to search, seperated by commas(\",\"). You can use + and - to sea" +
        "rch for values that are greater/lesser or equal. Searching 80+ will find everyth" +
        "ing thats greater or equal to 80.");
            // 
            // buttonConfig
            // 
            this.buttonConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfig.Location = new System.Drawing.Point(584, 27);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(93, 23);
            this.buttonConfig.TabIndex = 15;
            this.buttonConfig.Text = "Configuration";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.ButtonConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Percentage Search:";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 500000;
            this.toolTip1.InitialDelay = 250;
            this.toolTip1.ReshowDelay = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Level:";
            this.toolTip1.SetToolTip(this.label2, "Used for perfect hp&mp, enter level you level up to.");
            // 
            // numericLevel
            // 
            this.numericLevel.Location = new System.Drawing.Point(380, 89);
            this.numericLevel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLevel.Name = "numericLevel";
            this.numericLevel.Size = new System.Drawing.Size(86, 20);
            this.numericLevel.TabIndex = 21;
            this.toolTip1.SetToolTip(this.numericLevel, "Used for perfect hp&mp, enter level you level up to.");
            this.numericLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(689, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // searchesToolStripMenuItem
            // 
            this.searchesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchMenu20002,
            this.searchMenu3Search,
            this.searchMenu1Search,
            this.searchMenuHighestPerfect,
            this.searchMenu1256});
            this.searchesToolStripMenuItem.Name = "searchesToolStripMenuItem";
            this.searchesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.searchesToolStripMenuItem.Text = "Searches";
            // 
            // searchMenu20002
            // 
            this.searchMenu20002.Name = "searchMenu20002";
            this.searchMenu20002.Size = new System.Drawing.Size(185, 22);
            this.searchMenu20002.Text = "20002 Search";
            this.searchMenu20002.Click += new System.EventHandler(this.Button20002Search_Click);
            // 
            // searchMenu3Search
            // 
            this.searchMenu3Search.Name = "searchMenu3Search";
            this.searchMenu3Search.Size = new System.Drawing.Size(185, 22);
            this.searchMenu3Search.Text = "3 Search";
            this.searchMenu3Search.Click += new System.EventHandler(this.Button3Search_Click);
            // 
            // searchMenu1Search
            // 
            this.searchMenu1Search.Name = "searchMenu1Search";
            this.searchMenu1Search.Size = new System.Drawing.Size(185, 22);
            this.searchMenu1Search.Text = "First Perfect Level";
            this.searchMenu1Search.Click += new System.EventHandler(this.SearchMenu1Search_Click);
            // 
            // searchMenuHighestPerfect
            // 
            this.searchMenuHighestPerfect.Name = "searchMenuHighestPerfect";
            this.searchMenuHighestPerfect.Size = new System.Drawing.Size(185, 22);
            this.searchMenuHighestPerfect.Text = "Highest Perfect Level";
            this.searchMenuHighestPerfect.Click += new System.EventHandler(this.SearchMenuHighestPerfect_Click);
            // 
            // searchMenu1256
            // 
            this.searchMenu1256.Name = "searchMenu1256";
            this.searchMenu1256.Size = new System.Drawing.Size(185, 22);
            this.searchMenu1256.Text = "1/256";
            this.searchMenu1256.Click += new System.EventHandler(this.SearchMenu1256_Click);
            // 
            // buttonRngInjection
            // 
            this.buttonRngInjection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRngInjection.Location = new System.Drawing.Point(584, 56);
            this.buttonRngInjection.Name = "buttonRngInjection";
            this.buttonRngInjection.Size = new System.Drawing.Size(92, 23);
            this.buttonRngInjection.TabIndex = 23;
            this.buttonRngInjection.Text = "RNG Injection";
            this.buttonRngInjection.UseVisualStyleBackColor = true;
            this.buttonRngInjection.Click += new System.EventHandler(this.ButtonRngInjection_Click);
            // 
            // numericGil
            // 
            this.numericGil.Location = new System.Drawing.Point(380, 63);
            this.numericGil.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericGil.Name = "numericGil";
            this.numericGil.Size = new System.Drawing.Size(86, 20);
            this.numericGil.TabIndex = 24;
            this.numericGil.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Gil:";
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 463);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericGil);
            this.Controls.Add(this.buttonRngInjection);
            this.Controls.Add(this.numericLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConfig);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.stepsToResult);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridView2);
            this.MinimumSize = new System.Drawing.Size(620, 490);
            this.Name = "Form1";
            this.Text = "FF12PCRNGHelper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.gridRightClickMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericLevel)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private Button buttonSearch;
        private Label stepsToResult;
        private TextBox tbSearch;
        private Button buttonConfig;
        private Label label1;
        private ToolTip toolTip1;
        private ContextMenuStrip gridRightClickMenu;
        private ToolStripMenuItem buttonGridDump;
        private Label label2;
        private NumericUpDown numericLevel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem searchesToolStripMenuItem;
        private ToolStripMenuItem searchMenu20002;
        private ToolStripMenuItem searchMenu3Search;
        private ToolStripMenuItem searchMenuHighestPerfect;
        private ToolStripMenuItem searchMenu1Search;
        private ToolStripMenuItem searchMenu1256;
        private Button buttonRngInjection;
        private NumericUpDown numericGil;
        private Label label3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column1;
    }
}