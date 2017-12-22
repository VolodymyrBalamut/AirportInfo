namespace AirportInfo.view
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFlights = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConf = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.довідникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCity = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAirport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPlane = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripMenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAFlights = new System.Windows.Forms.ToolStripMenuItem();
            this.історіяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.налаштуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFlights,
            this.toolStripMenuItemAFlights,
            this.довідникиToolStripMenuItem,
            this.toolStripMenuItemConf});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1001, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItemFlights
            // 
            this.toolStripMenuItemFlights.Name = "toolStripMenuItemFlights";
            this.toolStripMenuItemFlights.Size = new System.Drawing.Size(101, 20);
            this.toolStripMenuItemFlights.Text = "Розклад рейсів";
            this.toolStripMenuItemFlights.Click += new System.EventHandler(this.toolStripMenuItemFlights_Click);
            // 
            // toolStripMenuItemConf
            // 
            this.toolStripMenuItemConf.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemStatus,
            this.toolStripMenuItemSetting});
            this.toolStripMenuItemConf.Name = "toolStripMenuItemConf";
            this.toolStripMenuItemConf.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItemConf.Text = "Система";
            // 
            // toolStripMenuItemStatus
            // 
            this.toolStripMenuItemStatus.Name = "toolStripMenuItemStatus";
            this.toolStripMenuItemStatus.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemStatus.Text = "Оновити статуси";
            this.toolStripMenuItemStatus.Click += new System.EventHandler(this.toolStripMenuItemStatus_Click);
            // 
            // довідникиToolStripMenuItem
            // 
            this.довідникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCountry,
            this.toolStripMenuItemCity,
            this.toolStripMenuItemAirport,
            this.toolStripMenuItemPlane,
            this.toolStripMenuItemCompany});
            this.довідникиToolStripMenuItem.Name = "довідникиToolStripMenuItem";
            this.довідникиToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.довідникиToolStripMenuItem.Text = "Довідники";
            // 
            // toolStripMenuItemCountry
            // 
            this.toolStripMenuItemCountry.Name = "toolStripMenuItemCountry";
            this.toolStripMenuItemCountry.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemCountry.Text = "Країни";
            this.toolStripMenuItemCountry.Click += new System.EventHandler(this.toolStripMenuItemCountry_Click);
            // 
            // toolStripMenuItemCity
            // 
            this.toolStripMenuItemCity.Name = "toolStripMenuItemCity";
            this.toolStripMenuItemCity.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemCity.Text = "Міста";
            this.toolStripMenuItemCity.Click += new System.EventHandler(this.toolStripMenuItemCity_Click);
            // 
            // toolStripMenuItemAirport
            // 
            this.toolStripMenuItemAirport.Name = "toolStripMenuItemAirport";
            this.toolStripMenuItemAirport.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemAirport.Text = "Аеоропорти";
            this.toolStripMenuItemAirport.Click += new System.EventHandler(this.toolStripMenuItemAirport_Click);
            // 
            // toolStripMenuItemPlane
            // 
            this.toolStripMenuItemPlane.Name = "toolStripMenuItemPlane";
            this.toolStripMenuItemPlane.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemPlane.Text = "Літаки";
            this.toolStripMenuItemPlane.Click += new System.EventHandler(this.toolStripMenuItemPlane_Click);
            // 
            // toolStripMenuItemCompany
            // 
            this.toolStripMenuItemCompany.Name = "toolStripMenuItemCompany";
            this.toolStripMenuItemCompany.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemCompany.Text = "Перевізники";
            this.toolStripMenuItemCompany.Click += new System.EventHandler(this.toolStripMenuItemCompany_Click);
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(3, 0);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(918, 383);
            this.dgv.TabIndex = 1;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(743, 40);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(91, 20);
            this.dateTimePicker.TabIndex = 2;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(28, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(932, 409);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(924, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Відліт";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv2);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(924, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Приліт";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv2
            // 
            this.dgv2.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(0, 0);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(924, 380);
            this.dgv2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(668, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Дата";
            // 
            // toolStripMenuItemSetting
            // 
            this.toolStripMenuItemSetting.Name = "toolStripMenuItemSetting";
            this.toolStripMenuItemSetting.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemSetting.Text = "Налаштування";
            this.toolStripMenuItemSetting.Click += new System.EventHandler(this.toolStripMenuItemSetting_Click);
            // 
            // toolStripMenuItemAFlights
            // 
            this.toolStripMenuItemAFlights.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.історіяToolStripMenuItem,
            this.налаштуванняToolStripMenuItem});
            this.toolStripMenuItemAFlights.Name = "toolStripMenuItemAFlights";
            this.toolStripMenuItemAFlights.Size = new System.Drawing.Size(52, 20);
            this.toolStripMenuItemAFlights.Text = "Рейси";
            // 
            // історіяToolStripMenuItem
            // 
            this.історіяToolStripMenuItem.Name = "історіяToolStripMenuItem";
            this.історіяToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.історіяToolStripMenuItem.Text = "Історія";
            this.історіяToolStripMenuItem.Click += new System.EventHandler(this.історіяToolStripMenuItem_Click);
            // 
            // налаштуванняToolStripMenuItem
            // 
            this.налаштуванняToolStripMenuItem.Name = "налаштуванняToolStripMenuItem";
            this.налаштуванняToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.налаштуванняToolStripMenuItem.Text = "Налаштування";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrchid;
            this.ClientSize = new System.Drawing.Size(1001, 505);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FormMain";
            this.Text = "Головна форма";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFlights;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConf;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem довідникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCountry;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCity;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAirport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlane;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCompany;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAFlights;
        private System.Windows.Forms.ToolStripMenuItem історіяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem налаштуванняToolStripMenuItem;
    }
}