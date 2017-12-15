using AirportData;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AirportInfo.view
{
    public partial class FormPlane : Form
    {
        protected SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AirportInfo.Properties.Settings.dbAirportInfoConnectionString"].ConnectionString);
        protected DataSet ds;
        protected SqlDataAdapter da;
        public FormPlane()
        {
            InitializeComponent();
        }

        private void FormPlane_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            da = new SqlDataAdapter("select * from tbPlane", conn);
            this.BackColor = Color.DarkOrchid;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            da.Fill(ds, "tbPlane");
            dgv.DataSource = ds;
            dgv.DataMember = "tbPlane";
            dgv.Columns["PlaneCode"].HeaderText = "Код літака";
            dgv.Columns["PlaneName"].HeaderText = "Літак";
            dgv.Columns["Speed"].HeaderText = "Швидкість";
            dgv.Columns["Distance"].HeaderText = "Дистанція";
            dgv.Columns["Seats"].HeaderText = "Місця";
            dgv.AutoResizeColumns();
            dgv.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Plane.Refresh();
            ds.Clear();
            da.Fill(ds, "tbPlane");
        }
    }
}
