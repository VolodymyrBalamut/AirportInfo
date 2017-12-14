using AirportInfo.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportInfo.controller
{
    public class ControllerFlight : Controller<Flight>
    {
        Dictionary<string, ComboBox> comboBoxs;
        Dictionary<string, CheckBox> checkBoxs;
        Dictionary<string, TextBox> textBoxs;
        public ControllerFlight(DataGridView dgv, BindingNavigator bn, Dictionary<string, ComboBox> comboBoxs, Dictionary<string, CheckBox> checkBoxs, Dictionary<string, TextBox> textBoxs) : base(dgv,bn)
        {
            this.comboBoxs = comboBoxs;
            new Airport().Get();
            new Company().Get();
            new Plane().Get();
            //bindings depart airport
            
            //this.comboBoxs["cbDepartAirport"].DataBindings.Add("Text", bindingSource, "DepartAirport");
            this.comboBoxs["cbDepartAirport"].DataSource = Airport.Items.Values.ToList();
            //bindings arrive airport
            this.comboBoxs["cbArriveAirport"].DataSource = Airport.Items.Values.ToList();
            //this.comboBoxs["cbArriveAirport"].DataBindings.Add("Text", bindingSource, "ArriveAirport");
            

            //bindings company
            this.comboBoxs["cbCompany"].DataSource = Company.Items.Values.ToList();
            //this.comboBoxs["cbCompany"].DataBindings.Add("Text", bindingSource, "Company");
            //bindings plane
            this.comboBoxs["cbPlane"].DataSource = Plane.Items.Values.ToList();
            //this.comboBoxs["cbPlane"].DataBindings.Add("Text", bindingSource, "Plane");

            this.checkBoxs = checkBoxs;
            //this.checkBoxs["Monday"].DataBindings.Add("Checked", bindingSource, "Monday");
            //this.checkBoxs["Tuesday"].DataBindings.Add("Checked", bindingSource, "Tuesday");
            //this.checkBoxs["Wednesday"].DataBindings.Add("Checked", bindingSource, "Wednesday");
            //this.checkBoxs["Thursday"].DataBindings.Add("Checked", bindingSource, "Thursday");
            //this.checkBoxs["Friday"].DataBindings.Add("Checked", bindingSource, "Friday");
            //this.checkBoxs["Suterday"].DataBindings.Add("Checked", bindingSource, "Suterday");
            //this.checkBoxs["Sunday"].DataBindings.Add("Checked", bindingSource, "Sunday");

            //bindings flight code
            this.textBoxs = textBoxs;
            //this.textBoxs["tbFlightCode"].DataBindings.Add("Text", bindingSource, "FlightCode");

            //depart and arrive time
            List<string> listHour1 = new List<string>();
            List<string> listHour2 = new List<string>();
            for (int i =0; i <= 24; i++)
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
            for (int i = 10; i < 60; i=i+5)
            {
                listMinutes1.Add(i.ToString());
                listMinutes2.Add(i.ToString());
            }
            this.comboBoxs["cbDepartHour"].DataSource = listHour1;
           // this.comboBoxs["cbDepartHour"].DataBindings.Add("Text", bindingSource, "DepartHour");
            this.comboBoxs["cbArriveHour"].DataSource = listHour2;
           // this.comboBoxs["cbArriveHour"].DataBindings.Add("Text", bindingSource, "ArriveHour");
            this.comboBoxs["cbDepartMinutes"].DataSource = listMinutes1;
            //this.comboBoxs["cbDepartMinutes"].DataBindings.Add("Text", bindingSource, "DepartMinutes");
            this.comboBoxs["cbArriveMinutes"].DataSource = listMinutes2;
            //this.comboBoxs["cbArriveMinutes"].DataBindings.Add("Text", bindingSource, "ArriveMinutes");
        }
        

        public override void Save()
        {
            /*Hotel hotel = new Hotel();
            hotel.Name = TextBoxs["Name"].Text;
            hotel.City = TextBoxs["City"].Text;
            hotel.Street = TextBoxs["Street"].Text;
            hotel.Email = TextBoxs["Email"].Text;
            hotel.Telephone = TextBoxs["Telephone"].Text;

            if (((DataRowView)bindingSource.Current).IsNew == true)
                hotel.Insert();
            else
            {
                hotel.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                hotel.Update();
            }*/
        }
        public void Add()
        {
            Flight flight = new Flight();
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
            flight.Insert();
        }
        public void Update()
        {
            Flight flight = new Flight();
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
            flight.Update();
        }
        public override void Delete()
        {
            Flight flight = new Flight();
            flight.FlightCode = (string)((DataRowView)bindingSource.Current).Row["FlightCode"];
            flight.Delete();
        }
        public override void LoadDB()
        {
            new Flight().Get();
            FillRows(Flight.Items.Values.ToArray());
            /*comboBoxs["cbDepartAirport"].DataSource; = Airport.Items.Values.ToList();*/
        }
        public override void FillColumns()
        {
            base.FillColumns();
            //hidden field
            dataGridView.Columns["Monday"].Visible = false;
            dataGridView.Columns["Tuesday"].Visible = false;
            dataGridView.Columns["Wednesday"].Visible = false;
            dataGridView.Columns["Thursday"].Visible = false;
            dataGridView.Columns["Friday"].Visible = false;
            dataGridView.Columns["Suterday"].Visible = false;
            dataGridView.Columns["Sunday"].Visible = false;
            dataGridView.Columns["DepartHour"].Visible = false;
            dataGridView.Columns["ArriveHour"].Visible = false;
            dataGridView.Columns["DepartMinutes"].Visible = false;
            dataGridView.Columns["ArriveMinutes"].Visible = false;
            //columns name
            dataGridView.Columns["DepartAirport"].HeaderText = "Аеропорт відправлення";
            dataGridView.Columns["ArriveAirport"].HeaderText = "Аеропорт призначення";
            dataGridView.Columns["Company"].HeaderText = "Перевізник";
            dataGridView.Columns["Plane"].HeaderText = "Літак";
            dataGridView.Columns["Weekday"].HeaderText = "Робочі дні";
            dataGridView.Columns["DepartTime"].HeaderText = "Час відправлення";
            dataGridView.Columns["ArriveTime"].HeaderText = "Час прильоту";
        }
    }
}
