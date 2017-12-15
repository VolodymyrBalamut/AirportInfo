using AirportData;
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
    public partial class FormCity : Form
    {
        protected SqlConnection conn = Base<Country,string>.conn;
        protected DataSet ds;
        protected SqlDataAdapter da;
        public FormCity()
        {
            InitializeComponent();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from vwCity", conn);
            this.BackColor = Color.DarkOrchid;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void FormCity_Load(object sender, EventArgs e)
        {
            da.Fill(ds, "vwCity");
            dgv.DataSource = ds;
            dgv.DataMember = "vwCity";
            dgv.Columns["CountryCode"].HeaderText = "Код країни";
            dgv.Columns["CountryName"].HeaderText = "Назва країни";
            dgv.Columns["CityName"].HeaderText = "Місто";
            dgv.AutoResizeColumns();
            dgv.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            City.Refresh();
            ds.Clear();
            da.Fill(ds, "vwCity");
        }
    }
}
