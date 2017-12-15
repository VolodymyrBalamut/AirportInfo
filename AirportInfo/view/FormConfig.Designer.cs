namespace AirportInfo.view
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAirport = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTerminal = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(265, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Налаштування";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(22, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Аеропорт";
            // 
            // cbAirport
            // 
            this.cbAirport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAirport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAirport.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbAirport.FormattingEnabled = true;
            this.cbAirport.Location = new System.Drawing.Point(134, 82);
            this.cbAirport.Name = "cbAirport";
            this.cbAirport.Size = new System.Drawing.Size(196, 24);
            this.cbAirport.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(22, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Термінали";
            // 
            // dgvTerminal
            // 
            this.dgvTerminal.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.dgvTerminal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerminal.Location = new System.Drawing.Point(134, 154);
            this.dgvTerminal.Name = "dgvTerminal";
            this.dgvTerminal.Size = new System.Drawing.Size(196, 150);
            this.dgvTerminal.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(363, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Користувачі";
            // 
            // dgvUser
            // 
            this.dgvUser.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(481, 154);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.Size = new System.Drawing.Size(196, 150);
            this.dgvUser.TabIndex = 20;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrchid;
            this.ClientSize = new System.Drawing.Size(696, 376);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvTerminal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAirport);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConfig";
            this.Text = "Налаштування";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAirport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTerminal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvUser;
    }
}