using AirportData;
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

namespace AirportInfo.view
{
    public partial class FormCountry : Form
    {
        protected SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AirportInfo.Properties.Settings.dbAirportInfoConnectionString"].ConnectionString);
        protected DataSet ds;
        protected SqlDataAdapter da;
        public FormCountry()
        {
            InitializeComponent();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from tbCountry", conn);
            this.BackColor = Color.DarkOrchid;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void FormCountry_Load(object sender, EventArgs e)
        {
            da.Fill(ds, "tbCountry");
            dgv.DataSource = ds;
            dgv.DataMember = "tbCountry";
            dgv.Columns["CountryCode"].HeaderText = "Код";
            dgv.Columns["CountryName"].HeaderText = "Назва";
            dgv.AutoResizeColumns();
            dgv.ReadOnly = true;
            if (FormLogin.user.UserRoleName == "user")
            {
                btnUpdate.Visible = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Country.Refresh();
            ds.Clear();
            da.Fill(ds, "tbCountry");
        }
    }
}
