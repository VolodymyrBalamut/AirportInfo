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
    public partial class FormAirport : Form
    {
        protected SqlConnection conn = Base<Country,string>.conn;
        protected DataSet ds;
        protected SqlDataAdapter da;
        public FormAirport()
        {
            InitializeComponent();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from vwAirport", conn);
            this.BackColor = Color.DarkOrchid;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void FormAirport_Load(object sender, EventArgs e)
        {
            da.Fill(ds, "vwAirport");
            dgv.DataSource = ds;
            dgv.DataMember = "vwAirport";
            dgv.Columns["AirportCode"].HeaderText = "Код аеропорту";
            dgv.Columns["AirportName"].HeaderText = "Аеропорт";
            dgv.Columns["CountryCode"].HeaderText = "Код країни";
            dgv.Columns["CountryName"].HeaderText = "Країна";
            dgv.Columns["CityName"].HeaderText = "Місто";
            dgv.AutoResizeColumns();
            dgv.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Airport.Refresh();
            ds.Clear();
            da.Fill(ds, "vwAirport");
        }
    }
}
