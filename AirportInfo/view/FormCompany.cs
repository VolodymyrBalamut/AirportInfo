using AirportInfo.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportInfo.view
{
    public partial class FormCompany : Form
    {
        protected SqlConnection conn = Base<Country>.conn;
        protected DataSet ds;
        protected SqlDataAdapter da;
        public FormCompany()
        {
            InitializeComponent();
        }

        private void FormCompany_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkOrchid;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            ds = new DataSet();
            da = new SqlDataAdapter("select * from vwCompany", conn);
            da.Fill(ds, "vwCompany");
            dgv.DataSource = ds;
            dgv.DataMember = "vwCompany";

            dgv.Columns["CompanyCode"].HeaderText = "Код компанії";
            dgv.Columns["CompanyName"].HeaderText = "Компанія";
            dgv.Columns["CountryName"].HeaderText = "Країна";
            dgv.Columns["Callsign"].HeaderText = "Дивіз";
            dgv.AutoResizeColumns();
            dgv.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Company.Refresh();
            ds.Clear();
            da.Fill(ds, "vwCompany");
        }
    }
}
