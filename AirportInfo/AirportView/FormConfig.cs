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
    public partial class FormConfig : Form
    {
        protected SqlConnection conn = Base<ActualFlight,int>.conn;
        protected DataSet ds;
        protected DataSet ds2;
        protected SqlDataAdapter da;
        protected SqlDataAdapter da2;
        public FormConfig()
        {
            InitializeComponent();
            ds = new DataSet();
            ds2 = new DataSet();
            da = new SqlDataAdapter("select * from tbTerminal", conn);
            da2 = new SqlDataAdapter("select * from tbUser", conn);
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkOrchid;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            da.Fill(ds, "tbTerminal");
            dgvTerminal.DataSource = ds;
            dgvTerminal.DataMember = "tbTerminal";
        }
    }
}
