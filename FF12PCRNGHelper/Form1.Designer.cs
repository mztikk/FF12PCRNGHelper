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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.buttonConfig = new System.Windows.Forms.Button();
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
            this.stepsToResult = new System.Windows.Forms.Label();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.dataGridView2.Location = new System.Drawing.Point(13, 221);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.RowHeadersWidth = 30;
            this.dataGridView2.Size = new System.Drawing.Size(1123, 654);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGridView2_KeyUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "i";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 32;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "%";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 35;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "1/256?";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Steal";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Steal w/ cuffs";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Perfect HP&MP";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Gil";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 35;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Value";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "mti";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 32;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "mt";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridRightClickMenu
            // 
            this.gridRightClickMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.gridRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonGridDump});
            this.gridRightClickMenu.Name = "gridRightClickMenu";
            this.gridRightClickMenu.Size = new System.Drawing.Size(225, 36);
            // 
            // buttonGridDump
            // 
            this.buttonGridDump.Name = "buttonGridDump";
            this.buttonGridDump.Size = new System.Drawing.Size(224, 32);
            this.buttonGridDump.Text = "Dump (CTRL + Q)";
            this.buttonGridDump.Click += new System.EventHandler(this.ButtonGridDump_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSearch.BackgroundImage")));
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.buttonSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(214)))));
            this.buttonSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Location = new System.Drawing.Point(185, 52);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(42, 42);
            this.buttonSearch.TabIndex = 12;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.ForeColor = System.Drawing.Color.White;
            this.tbSearch.Location = new System.Drawing.Point(13, 59);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(164, 31);
            this.tbSearch.TabIndex = 14;
            this.toolTip1.SetToolTip(this.tbSearch, "Enter percentages to search, seperated by commas(\",\"). You can use + and - to sea" +
        "rch for values that are greater/lesser or equal. Searching 80+ will find everyth" +
        "ing thats greater or equal to 80.");
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // buttonConfig
            // 
            this.buttonConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonConfig.BackgroundImage")));
            this.buttonConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.buttonConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(214)))));
            this.buttonConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
            this.buttonConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig.ForeColor = System.Drawing.Color.Transparent;
            this.buttonConfig.Location = new System.Drawing.Point(1093, 52);
            this.buttonConfig.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(43, 43);
            this.buttonConfig.TabIndex = 15;
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.ButtonConfig_Click);
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
            this.label2.Location = new System.Drawing.Point(560, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Level:";
            this.toolTip1.SetToolTip(this.label2, "Used for perfect hp&mp, enter level you level up to.");
            // 
            // numericLevel
            // 
            this.numericLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.numericLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericLevel.ForeColor = System.Drawing.Color.White;
            this.numericLevel.Location = new System.Drawing.Point(623, 59);
            this.numericLevel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.numericLevel.Size = new System.Drawing.Size(128, 31);
            this.numericLevel.TabIndex = 21;
            this.numericLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.numericLevel, "Used for perfect hp&mp, enter level you level up to.");
            this.numericLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLevel.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(147)))));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1149, 37);
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
            this.searchesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.searchesToolStripMenuItem.Name = "searchesToolStripMenuItem";
            this.searchesToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.searchesToolStripMenuItem.Text = "Searches";
            // 
            // searchMenu20002
            // 
            this.searchMenu20002.Name = "searchMenu20002";
            this.searchMenu20002.Size = new System.Drawing.Size(277, 34);
            this.searchMenu20002.Text = "20002 Search";
            this.searchMenu20002.Click += new System.EventHandler(this.Button20002Search_Click);
            // 
            // searchMenu3Search
            // 
            this.searchMenu3Search.Name = "searchMenu3Search";
            this.searchMenu3Search.Size = new System.Drawing.Size(277, 34);
            this.searchMenu3Search.Text = "3 Search";
            this.searchMenu3Search.Click += new System.EventHandler(this.Button3Search_Click);
            // 
            // searchMenu1Search
            // 
            this.searchMenu1Search.Name = "searchMenu1Search";
            this.searchMenu1Search.Size = new System.Drawing.Size(277, 34);
            this.searchMenu1Search.Text = "First Perfect Level";
            this.searchMenu1Search.Click += new System.EventHandler(this.SearchMenu1Search_Click);
            // 
            // searchMenuHighestPerfect
            // 
            this.searchMenuHighestPerfect.Name = "searchMenuHighestPerfect";
            this.searchMenuHighestPerfect.Size = new System.Drawing.Size(277, 34);
            this.searchMenuHighestPerfect.Text = "Highest Perfect Level";
            this.searchMenuHighestPerfect.Click += new System.EventHandler(this.SearchMenuHighestPerfect_Click);
            // 
            // searchMenu1256
            // 
            this.searchMenu1256.Name = "searchMenu1256";
            this.searchMenu1256.Size = new System.Drawing.Size(277, 34);
            this.searchMenu1256.Text = "1/256";
            this.searchMenu1256.Click += new System.EventHandler(this.SearchMenu1256_Click);
            // 
            // buttonRngInjection
            // 
            this.buttonRngInjection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRngInjection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRngInjection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRngInjection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.buttonRngInjection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(214)))));
            this.buttonRngInjection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
            this.buttonRngInjection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRngInjection.ForeColor = System.Drawing.Color.Transparent;
            this.buttonRngInjection.Image = ((System.Drawing.Image)(resources.GetObject("buttonRngInjection.Image")));
            this.buttonRngInjection.Location = new System.Drawing.Point(1093, 107);
            this.buttonRngInjection.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonRngInjection.Name = "buttonRngInjection";
            this.buttonRngInjection.Size = new System.Drawing.Size(43, 44);
            this.buttonRngInjection.TabIndex = 23;
            this.buttonRngInjection.UseVisualStyleBackColor = true;
            this.buttonRngInjection.Click += new System.EventHandler(this.ButtonRngInjection_Click);
            // 
            // numericGil
            // 
            this.numericGil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.numericGil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericGil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericGil.ForeColor = System.Drawing.Color.White;
            this.numericGil.Location = new System.Drawing.Point(368, 59);
            this.numericGil.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.numericGil.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericGil.Name = "numericGil";
            this.numericGil.Size = new System.Drawing.Size(128, 31);
            this.numericGil.TabIndex = 24;
            this.numericGil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericGil.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericGil.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Gil:";
            // 
            // stepsToResult
            // 
            this.stepsToResult.AutoSize = true;
            this.stepsToResult.Location = new System.Drawing.Point(20, 185);
            this.stepsToResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stepsToResult.Name = "stepsToResult";
            this.stepsToResult.Size = new System.Drawing.Size(111, 25);
            this.stepsToResult.TabIndex = 13;
            this.stepsToResult.Text = "SearchResult";
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1149, 890);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericGil);
            this.Controls.Add(this.buttonRngInjection);
            this.Controls.Add(this.numericLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonConfig);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.stepsToResult);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridView2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MinimumSize = new System.Drawing.Size(1019, 891);
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
        private TextBox tbSearch;
        private Button buttonConfig;
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
        private Label stepsToResult;
    }
}