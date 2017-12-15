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
    public partial class FormPlane : Form
    {
        protected SqlConnection conn = Base<Country>.conn;
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
