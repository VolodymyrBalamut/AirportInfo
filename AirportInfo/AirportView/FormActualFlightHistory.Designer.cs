namespace AirportInfo.AirportView
{
    partial class FormActualFlightHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActualFlightHistory));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDepartHistory = new System.Windows.Forms.DataGridView();
            this.dgvDepart = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvArriveHistory = new System.Windows.Forms.DataGridView();
            this.dgvArrive = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArriveHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrive)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(27, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(936, 392);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDepartHistory);
            this.tabPage1.Controls.Add(this.dgvDepart);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(928, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Відліт";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDepartHistory
            // 
            this.dgvDepartHistory.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.dgvDepartHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartHistory.Location = new System.Drawing.Point(6, 211);
            this.dgvDepartHistory.Name = "dgvDepartHistory";
            this.dgvDepartHistory.Size = new System.Drawing.Size(918, 138);
            this.dgvDepartHistory.TabIndex = 1;
            // 
            // dgvDepart
            // 
            this.dgvDepart.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.dgvDepart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepart.Location = new System.Drawing.Point(6, 17);
            this.dgvDepart.Name = "dgvDepart";
            this.dgvDepart.Size = new System.Drawing.Size(918, 173);
            this.dgvDepart.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvArriveHistory);
            this.tabPage2.Controls.Add(this.dgvArrive);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(928, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Приліт";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvArriveHistory
            // 
            this.dgvArriveHistory.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.dgvArriveHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArriveHistory.Location = new System.Drawing.Point(6, 211);
            this.dgvArriveHistory.Name = "dgvArriveHistory";
            this.dgvArriveHistory.Size = new System.Drawing.Size(918, 138);
            this.dgvArriveHistory.TabIndex = 2;
            // 
            // dgvArrive
            // 
            this.dgvArrive.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.dgvArrive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArrive.Location = new System.Drawing.Point(6, 17);
            this.dgvArrive.Name = "dgvArrive";
            this.dgvArrive.Size = new System.Drawing.Size(918, 173);
            this.dgvArrive.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(559, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Дата";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(634, 15);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(91, 20);
            this.dateTimePicker.TabIndex = 14;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // FormActualFlightHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrchid;
            this.ClientSize = new System.Drawing.Size(986, 442);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormActualFlightHistory";
            this.Text = "Історія зміни статусів рейсів";
            this.Load += new System.EventHandler(this.FormActualFlightHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArriveHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvDepartHistory;
        private System.Windows.Forms.DataGridView dgvDepart;
        private System.Windows.Forms.DataGridView dgvArriveHistory;
        private System.Windows.Forms.DataGridView dgvArrive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}