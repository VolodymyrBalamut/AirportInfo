using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AirportInfo.view
{
    public partial class FormMain : Form
    {
        protected SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AirportInfo.Properties.Settings.dbAirportInfoConnectionString"].ConnectionString);
        protected DataSet ds;
        protected DataSet ds2;
        protected SqlDataAdapter da;
        protected SqlDataAdapter da2;

        public FormMain()
        {
            InitializeComponent();
            Form form = new FormLogin();
            form.ShowDialog();
           
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.AutoResizeColumns();
            dgv2.AutoResizeColumns();
        }

        private void RefreshFlights(string date)
        {
            try
            {
                ds.Clear();
                ds2.Clear();
                da = new SqlDataAdapter("select * from vwActualFlightDepart where ActualFlightDate='" + date + "'", conn);
                da2 = new SqlDataAdapter("select * from vwActualFlightArrive where ActualFlightDate='" + date + "'", conn);
                da.Fill(ds, "vwActualFlightDepart");
                da2.Fill(ds, "vwActualFlightArrive");
                dgv.AutoResizeColumns();
                dgv2.AutoResizeColumns();
            }
            catch { }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshFlights(dateTimePicker.Value.ToString("yyyy-MM-dd"));
        }

        private void toolStripMenuItemFlights_Click(object sender, EventArgs e)
        {
            FormFlights form = new FormFlights();
            form.ShowDialog();
        }
        private void toolStripMenuItemConf_Click(object sender, EventArgs e)
        {
            FormConfig form = new FormConfig();
            form.ShowDialog();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds2 = new DataSet();
            string date = dateTimePicker.Value.ToString("yyyy-MM-dd");
            da = new SqlDataAdapter("select * from vwActualFlightDepart where ActualFlightDate='" + date + "'", conn);
            da2 = new SqlDataAdapter("select * from vwActualFlightArrive where ActualFlightDate='" + date + "'", conn);
            this.BackColor = Color.DarkOrchid;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            da.Fill(ds, "vwActualFlightDepart");
            dgv.DataSource = ds;
            dgv.DataMember = "vwActualFlightDepart";
            dgv.Columns["FlightCode"].HeaderText = "Рейс";
            dgv.Columns["ArriveAirportCity"].HeaderText = "Призначення";
            dgv.Columns["CompanyName"].HeaderText = "Перевізник";
            dgv.Columns["PlaneCode"].HeaderText = "Літак";
            dgv.Columns["DepartTime"].HeaderText = "Час";
            dgv.Columns["TerminalCode"].HeaderText = "Термінал";
            dgv.Columns["StatusFlight"].HeaderText = "Статус";
            dgv.Columns["ActualFlightDate"].Visible = false;
            dgv.AutoResizeColumns();
            dgv.ReadOnly = true;

            da2.Fill(ds, "vwActualFlightArrive");
            dgv2.DataSource = ds;
            dgv2.DataMember = "vwActualFlightArrive";
            dgv2.Columns["FlightCode"].HeaderText = "Рейс";
            dgv2.Columns["DepartAirportCity"].HeaderText = "Відправлення";
            dgv2.Columns["CompanyName"].HeaderText = "Перевізник";
            dgv2.Columns["PlaneCode"].HeaderText = "Літак";
            dgv2.Columns["ArriveTime"].HeaderText = "Час";
            dgv2.Columns["TerminalCode"].HeaderText = "Термінал";
            dgv2.Columns["StatusFlight"].HeaderText = "Статус";
            dgv2.Columns["ActualFlightDate"].Visible = false;
            dgv2.ReadOnly = true;
        }

        private void toolStripMenuItemCountry_Click(object sender, EventArgs e)
        {
            FormCountry form = new FormCountry();
            form.ShowDialog();
        }

        private void toolStripMenuItemCity_Click(object sender, EventArgs e)
        {
            FormCity form = new FormCity();
            form.ShowDialog();
        }

        private void toolStripMenuItemAirport_Click(object sender, EventArgs e)
        {
            FormAirport form = new FormAirport();
            form.ShowDialog();
        }

        private void toolStripMenuItemPlane_Click(object sender, EventArgs e)
        {
            FormPlane form = new FormPlane();
            form.ShowDialog();
        }

        private void toolStripMenuItemCompany_Click(object sender, EventArgs e)
        {
            FormCompany form = new FormCompany();
            form.ShowDialog();
        }
    }
}
