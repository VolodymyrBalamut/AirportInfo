using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportInfo.AirportView
{
    public partial class FormUser : Form
    {
        protected SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AirportInfo.Properties.Settings.dbAirportInfoConnectionString"].ConnectionString);
        protected DataSet ds;
        protected SqlDataAdapter da;
        protected SqlCommandBuilder cmdBldr;

        public FormUser()
        {
            InitializeComponent();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from tbUser", conn);
            cmdBldr = new SqlCommandBuilder(da);
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            da.Fill(ds, "tbUser");
            dgv.DataSource = ds;
            dgv.DataMember = "tbUser";
            dgv.AutoResizeColumns();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(ds, "tbUser");
                MessageBox.Show("Оновлення пройшло успішоно", "Оновлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Оновлення даних не відбулося", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
