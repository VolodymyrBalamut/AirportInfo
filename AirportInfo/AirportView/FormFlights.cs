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

namespace AirportInfo
{
    public partial class FormFlights : Form
    {
        protected SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AirportInfo.Properties.Settings.dbAirportInfoConnectionString"].ConnectionString);
        protected DataSet ds;
        protected SqlDataAdapter da;
        protected SqlCommandBuilder cmdBldr;
        bool flag = false;
        Dictionary<string, ComboBox> comboBoxs;
        Dictionary<string, CheckBox> checkBoxs;
        Dictionary<string, TextBox> textBoxs;
        public FormFlights()
        {
            InitializeComponent();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from vwFlight order by Convert(int,FlightCode)", conn);
            cmdBldr = new SqlCommandBuilder(da);

            
            comboBoxs = new Dictionary<string, ComboBox>();
            checkBoxs = new Dictionary<string, CheckBox>();
            textBoxs = new Dictionary<string, TextBox>();
            //checkedListDays.Items[0] = true;
            //checkedListDays.SetItemCheckState(0, CheckState.Checked);
            comboBoxs.Add("cbDepartAirport", cbDepartAirport);
            comboBoxs.Add("cbArriveAirport", cbArriveAirport);
            comboBoxs.Add("cbCompany", cbCompany);
            comboBoxs.Add("cbPlane", cbPlane);
            comboBoxs.Add("cbDepartHour", cbDepartHour);
            comboBoxs.Add("cbArriveHour", cbArriveHour);
            comboBoxs.Add("cbDepartMinutes", cbDepartMinutes); 
            comboBoxs.Add("cbArriveMinutes", cbArriveMinutes);
            

            checkBoxs.Add("Monday", checkBoxMonday);
            checkBoxs.Add("Tuesday", checkBoxTuesday);
            checkBoxs.Add("Wednesday", checkBoxWednesday);
            checkBoxs.Add("Thursday", checkBoxThursday);
            checkBoxs.Add("Friday", checkBoxFriday);
            checkBoxs.Add("Suterday", checkBoxSuterday);
            checkBoxs.Add("Sunday", checkBoxSunday);

            textBoxs.Add("tbFlightCode", tbFlightCode);
        }

        private void FormFlights_Load(object sender, EventArgs e)
        {
            da.Fill(ds, "vwFlight");
            dgvFlights.DataSource = ds;
            dgvFlights.DataMember = "vwFlight";
            dgvFlights.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFlights.Rows[0].Selected = true;
            dgvFlights.MultiSelect = false;
            flag = true;
            dgvFlights.Columns["FlightCode"].HeaderText = "Код рейсу";
            dgvFlights.Columns["DepartAirportName"].HeaderText = "Аеропорт відправлення";
            dgvFlights.Columns["ArriveAirportName"].HeaderText = "Аеропорт призначення";
            dgvFlights.Columns["CompanyName"].HeaderText = "Перевізник";
            dgvFlights.Columns["PlaneCode"].HeaderText = "Літак";
            dgvFlights.Columns["Weekday"].HeaderText = "Робочі дні";
            dgvFlights.Columns["DepartTime"].HeaderText = "Час відправлення";
            dgvFlights.Columns["ArriveTime"].HeaderText = "Час прильоту";
            dgvFlights.AutoResizeColumns();
            FillForm();
        }
        private void FillForm()
        {
            new Airport().GetAll();
            new Company().GetAll();
            new Plane().GetAll();

            comboBoxs["cbDepartAirport"].DataSource = Airport.Items.Values.ToList();
            comboBoxs["cbArriveAirport"].DataSource = Airport.Items.Values.ToList();
            comboBoxs["cbCompany"].DataSource = Company.Items.Values.ToList();
            comboBoxs["cbPlane"].DataSource = Plane.Items.Values.ToList();
            List<string> listHour1 = new List<string>();
            List<string> listHour2 = new List<string>();
            for (int i = 0; i <= 24; i++)
            {
                listHour1.Add(i.ToString());
                listHour2.Add(i.ToString());
            }
            List<string> listMinutes1 = new List<string>();
            List<string> listMinutes2 = new List<string>();
            listMinutes1.Add("00");
            listMinutes2.Add("00");
            listMinutes1.Add("05");
            listMinutes2.Add("05");
            for (int i = 10; i < 60; i = i + 5)
            {
                listMinutes1.Add(i.ToString());
                listMinutes2.Add(i.ToString());
            }
            comboBoxs["cbDepartHour"].DataSource = listHour1;
            comboBoxs["cbArriveHour"].DataSource = listHour2;
            comboBoxs["cbDepartMinutes"].DataSource = listMinutes1;
            comboBoxs["cbArriveMinutes"].DataSource = listMinutes2;
        }

        private void showFlight()
        {
            string FlightCode = getSelectedRow();
            if (FlightCode != "")
            {
                Flight flight = Flight.GetFlight(FlightCode);
                comboBoxs["cbDepartAirport"].Text = flight.DepartAirport.AirportName;
                comboBoxs["cbArriveAirport"].Text = flight.ArriveAirport.AirportName;
                comboBoxs["cbCompany"].Text = flight.Company.CompanyName;
                comboBoxs["cbPlane"].Text = flight.Plane.PlaneCode;
                comboBoxs["cbDepartHour"].Text = flight.DepartHour;
                comboBoxs["cbArriveHour"].Text = flight.ArriveHour;
                comboBoxs["cbDepartMinutes"].Text = flight.DepartMinutes;
                comboBoxs["cbArriveMinutes"].Text = flight.ArriveMinutes;
                checkBoxs["Monday"].Checked = flight.Monday;
                checkBoxs["Tuesday"].Checked = flight.Tuesday;
                checkBoxs["Wednesday"].Checked = flight.Wednesday;
                checkBoxs["Thursday"].Checked = flight.Thursday;
                checkBoxs["Friday"].Checked = flight.Friday;
                checkBoxs["Suterday"].Checked = flight.Suterday;
                checkBoxs["Sunday"].Checked = flight.Sunday;
                textBoxs["tbFlightCode"].Text = flight.FlightCode;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            btnUpdate.Enabled  = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void ClearForm()
        {
            comboBoxs["cbDepartAirport"].Text = "";
            comboBoxs["cbArriveAirport"].Text = "";
            comboBoxs["cbCompany"].Text = "";
            comboBoxs["cbPlane"].Text = "";
            comboBoxs["cbDepartHour"].Text = "0";
            comboBoxs["cbArriveHour"].Text = "0";
            comboBoxs["cbDepartMinutes"].Text = "00";
            comboBoxs["cbArriveMinutes"].Text = "00";
            checkBoxs["Monday"].Checked = false;
            checkBoxs["Tuesday"].Checked = false;
            checkBoxs["Wednesday"].Checked = false;
            checkBoxs["Thursday"].Checked = false;
            checkBoxs["Friday"].Checked = false;
            checkBoxs["Suterday"].Checked = false;
            checkBoxs["Sunday"].Checked = false;
            textBoxs["tbFlightCode"].Text = "";
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Flight flight = new Flight();
            if (textBoxs["tbFlightCode"].Text!="") {
                flight.FlightCode = textBoxs["tbFlightCode"].Text;
                flight.DepartTime = comboBoxs["cbDepartHour"].Text + ":" + comboBoxs["cbDepartMinutes"].Text;
                flight.ArriveTime = comboBoxs["cbArriveHour"].Text + ":" + comboBoxs["cbArriveMinutes"].Text;
                flight.DepartAirport = (Airport)comboBoxs["cbDepartAirport"].SelectedItem;
                flight.ArriveAirport = (Airport)comboBoxs["cbArriveAirport"].SelectedItem;
                flight.Company = (Company)comboBoxs["cbCompany"].SelectedItem;
                flight.Plane = (Plane)comboBoxs["cbPlane"].SelectedItem;
                if (checkBoxs["Monday"].Checked) flight.WeekDay += "1";
                else flight.WeekDay += "0";
                if (checkBoxs["Tuesday"].Checked) flight.WeekDay += "2";
                else flight.WeekDay += "0";
                if (checkBoxs["Wednesday"].Checked) flight.WeekDay += "3";
                else flight.WeekDay += "0";
                if (checkBoxs["Thursday"].Checked) flight.WeekDay += "4";
                else flight.WeekDay += "0";
                if (checkBoxs["Friday"].Checked) flight.WeekDay += "5";
                else flight.WeekDay += "0";
                if (checkBoxs["Suterday"].Checked) flight.WeekDay += "6";
                else flight.WeekDay += "0";
                if (checkBoxs["Sunday"].Checked) flight.WeekDay += "7";
                else flight.WeekDay += "0";

                if (Flight.GetFlight(flight.FlightCode).FlightCode != flight.FlightCode)
                    flight.Insert();
                else
                {
                    flight.Update();
                }
            }
            RefreshFlights();
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
        }
        private void RefreshFlights()
        {
            ds.Clear();
            da.Fill(ds, "vwFlight");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Ви справді хочете видалити рейс?",
            "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                string FlightCode = getSelectedRow();
                if (FlightCode != "")
                {
                    Flight flight = Flight.GetFlight(FlightCode);
                    flight.Delete();
                    RefreshFlights();
                }
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
        }


        private void dgvFlights_SelectionChanged(object sender, EventArgs e)
        {
            if (flag)
            {
               // MessageBox.Show("Changed " + getSelectedRow());
                showFlight();
            }
        }

        private string getSelectedRow()
        {
            string FlightCode = "";
            try
            {
                FlightCode = dgvFlights.Rows[dgvFlights.SelectedRows[0].Index].Cells[0].Value.ToString();
            }
            catch
            {
                ClearForm();
            }
            return FlightCode;
        }
    }
}
