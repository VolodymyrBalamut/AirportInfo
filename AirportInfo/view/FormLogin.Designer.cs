namespace AirportInfo.view
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShow.ForeColor = System.Drawing.Color.Gold;
            this.checkBoxShow.Location = new System.Drawing.Point(165, 185);
            this.checkBoxShow.Name = "checkBoxShow";
            this.checkBoxShow.Size = new System.Drawing.Size(141, 20);
            this.checkBoxShow.TabIndex = 29;
            this.checkBoxShow.Text = "Показати пароль";
            this.checkBoxShow.UseVisualStyleBackColor = true;
            this.checkBoxShow.CheckedChanged += new System.EventHandler(this.checkBoxShow_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(124, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 28;
            this.label3.Text = "Авторизація";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(37, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 27;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(37, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "Логін";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(165, 150);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(157, 20);
            this.tbPassword.TabIndex = 25;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(165, 84);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(157, 20);
            this.tbLogin.TabIndex = 24;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Crimson;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(196, 236);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(126, 38);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "Вихід";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(41, 236);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(126, 38);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrchid;
            this.ClientSize = new System.Drawing.Size(343, 300);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.checkBoxShow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOK;
    }
}