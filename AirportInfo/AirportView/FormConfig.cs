using AirportData.AirportModel;
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
        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkOrchid;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            new Airport().GetAll();
            cbAirport.DataSource = Airport.Items.Values.ToList();
            Config confAirport = Config.getAirportCurrent();
            cbAirport.Text = Airport.Items[confAirport.getVal()].AirportName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Airport newAirport = (Airport)cbAirport.SelectedItem;
            Config confAirport = new Config("AirportCode", newAirport.AirportCode);
           
            if (confAirport.Update())
            {
                MessageBox.Show("Аеропорт змінено на " + newAirport.AirportName, "Успіх",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Аеропорт не вдалося змінити", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
