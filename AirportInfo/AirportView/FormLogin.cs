using AirportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportInfo.view
{
    public partial class FormLogin : Form
    {
        public static User user;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            user = User.getUser(tbLogin.Text, tbPassword.Text);
            if (user.Login == tbLogin.Text && user.Password == tbPassword.Text)
            {
                MessageBox.Show("Добрий день,  " + user.Login, "Авторизація пройшла успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FormMain form = new FormMain();
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Дані введені невірно", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShow.Checked)
            {
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '*';
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
