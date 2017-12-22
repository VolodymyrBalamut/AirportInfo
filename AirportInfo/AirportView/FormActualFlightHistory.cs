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
    public partial class FormActualFlightHistory : Form
    {
        protected SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AirportInfo.Properties.Settings.dbAirportInfoConnectionString"].ConnectionString);
        protected DataSet ds;
        protected SqlDataAdapter daDepart;
        protected SqlDataAdapter daArrive;
        protected SqlDataAdapter daDepartHistory;
        protected SqlDataAdapter daArriveHistory;

        protected DataRelation relationDepart;
        protected DataRelation relationArrive;

        protected BindingSource bsDepart = new BindingSource();
        protected BindingSource bsDepartHistory = new BindingSource();
        protected BindingSource bsArrive = new BindingSource();
        protected BindingSource bsArriveHistory = new BindingSource();

        public FormActualFlightHistory()
        {
            InitializeComponent();
        }

        private void FormActualFlightHistory_Load(object sender, EventArgs e)
        {
            
            dgvDepart.DataSource = bsDepart;
            dgvDepartHistory.DataSource = bsDepartHistory;
            dgvArrive.DataSource = bsArrive;
            dgvArriveHistory.DataSource = bsArriveHistory;

            ds = new DataSet();
            //ds2 = new DataSet();
            string date = dateTimePicker.Value.ToString("yyyy-MM-dd");
            //Depart
            daDepart = new SqlDataAdapter("select * from vwActualFlightDepart where ActualFlightDate='" + date + "'", conn);
            daDepart.Fill(ds, "vwActualFlightDepart");
            daDepart.Dispose();
            //Arrive
            daArrive = new SqlDataAdapter("select * from vwActualFlightArrive where ActualFlightDate='" + date + "'", conn);
            daArrive.Fill(ds, "vwActualFlightArrive");
            daArrive.Dispose();
            //DepartHistory
            daDepartHistory = new SqlDataAdapter("select * from vwDepartHistory where  ActualFlightDate='" + date + "'", conn);
            daDepartHistory.Fill(ds, "vwDepartHistory");
            //ArriveHistory
            daArriveHistory = new SqlDataAdapter("select * from vwArriveHistory where  ActualFlightDate='" + date + "'", conn);
            daArriveHistory.Fill(ds, "vwArriveHistory");

            relationDepart = new DataRelation("DepartDepartHistory",
                ds.Tables["vwActualFlightDepart"].Columns["ActualFlightID"],
                ds.Tables["vwDepartHistory"].Columns["ActualFlightID"]);

            relationArrive = new DataRelation("ArriveArriveHistory",
                ds.Tables["vwActualFlightArrive"].Columns["ActualFlightID"],
                ds.Tables["vwArriveHistory"].Columns["ActualFlightID"]);

            ds.Relations.Add(relationDepart);
            ds.Relations.Add(relationArrive);
            //Depart
            bsDepart.DataSource = ds;
            bsDepart.DataMember = "vwActualFlightDepart";

            //Arrive
            bsArrive.DataSource = ds;
            bsArrive.DataMember = "vwActualFlightArrive";

            //DepartHistory
            bsDepartHistory.DataSource = bsDepart;
            bsDepartHistory.DataMember = "DepartDepartHistory";

            //ArriveHistory
            bsArriveHistory.DataSource = bsArrive;
            bsArriveHistory.DataMember = "ArriveArriveHistory";

            SettingTables();
            ResizeColumns();
            dgvDepart.Rows[0].Selected = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void RefreshFlights(string date)
        {
            try
            {
                ds.Clear();
                
                //ds2.Clear();
                //Depart
                daDepart = new SqlDataAdapter("select * from vwActualFlightDepart where ActualFlightDate='" + date + "'", conn);
                daDepart.Fill(ds, "vwActualFlightDepart");
                daDepart.Dispose();
                //Arrive
                daArrive = new SqlDataAdapter("select * from vwActualFlightArrive where ActualFlightDate='" + date + "'", conn);
                daArrive.Fill(ds, "vwActualFlightArrive");
                daArrive.Dispose();
                //DepartHistory
                daDepartHistory = new SqlDataAdapter("select * from vwDepartHistory where  ActualFlightDate='" + date + "'", conn);
                daDepartHistory.Fill(ds, "vwDepartHistory");
                //ArriveHistory
                daArriveHistory = new SqlDataAdapter("select * from vwArriveHistory where  ActualFlightDate='" + date + "'", conn);
                daArriveHistory.Fill(ds, "vwArriveHistory");
                
                
                ResizeColumns();
            }
            catch { }
        }

        private void ResizeColumns()
        {
            dgvDepart.AutoResizeColumns();
            dgvDepartHistory.AutoResizeColumns();
            dgvArrive.AutoResizeColumns();
            dgvArriveHistory.AutoResizeColumns();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshFlights(dateTimePicker.Value.ToString("yyyy-MM-dd"));
        }

        private void SettingTables()
        {
            this.BackColor = Color.DarkOrchid;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            dgvDepart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepart.MultiSelect = false;
            dgvArrive.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArrive.MultiSelect = false;
            dgvDepartHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepartHistory.MultiSelect = false;
            dgvArriveHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArriveHistory.MultiSelect = false;

            dgvDepart.Columns["FlightCode"].HeaderText = "Рейс";
            dgvDepart.Columns["ArriveAirportCity"].HeaderText = "Призначення";
            dgvDepart.Columns["CompanyName"].HeaderText = "Перевізник";
            dgvDepart.Columns["PlaneCode"].HeaderText = "Літак";
            dgvDepart.Columns["DepartTime"].HeaderText = "Час";
            dgvDepart.Columns["TerminalCode"].HeaderText = "Термінал";
            dgvDepart.Columns["StatusFlight"].HeaderText = "Статус";
            dgvDepart.Columns["ActualFlightDate"].Visible = false;
            dgvDepart.Columns["ActualFlightID"].Visible = false;
            dgvDepart.AutoResizeColumns();
            dgvDepart.ReadOnly = true;

            
            dgvArrive.Columns["FlightCode"].HeaderText = "Рейс";
            dgvArrive.Columns["DepartAirportCity"].HeaderText = "Відправлення";
            dgvArrive.Columns["CompanyName"].HeaderText = "Перевізник";
            dgvArrive.Columns["PlaneCode"].HeaderText = "Літак";
            dgvArrive.Columns["ArriveTime"].HeaderText = "Час";
            dgvArrive.Columns["TerminalCode"].HeaderText = "Термінал";
            dgvArrive.Columns["StatusFlight"].HeaderText = "Статус";
            dgvArrive.Columns["ActualFlightDate"].Visible = false;
            dgvArrive.Columns["ActualFlightID"].Visible = false;


            dgvDepartHistory.Columns["OldStatus"].HeaderText = "Старий статус";
            dgvDepartHistory.Columns["NewStatus"].HeaderText = "Новий статус";
            dgvDepartHistory.Columns["DateChange"].HeaderText = "Час";
            dgvDepartHistory.Columns["ActualFlightHistoryID"].Visible = false;
            dgvDepartHistory.Columns["ActualFlightID"].Visible = false;
            dgvDepartHistory.Columns["ActualFlightDate"].Visible = false;
            dgvDepartHistory.ReadOnly = true;

            dgvArriveHistory.Columns["OldStatus"].HeaderText = "Старий статус";
            dgvArriveHistory.Columns["NewStatus"].HeaderText = "Новий статус";
            dgvArriveHistory.Columns["DateChange"].HeaderText = "Час";
            dgvArriveHistory.Columns["ActualFlightHistoryID"].Visible = false;
            dgvArriveHistory.Columns["ActualFlightID"].Visible = false;
            dgvArriveHistory.Columns["ActualFlightDate"].Visible = false;
            dgvArriveHistory.ReadOnly = true;
        }
    }
}
