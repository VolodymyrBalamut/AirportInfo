using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirportData;

namespace AirportInfo.view
{
    public partial class FormActualFlightConf : Form
    {
        public FormActualFlightConf()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ActualFlight.GenerateActualFlight(dateTimePicker.Value.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("Рейси на " + dateTimePicker.Value.ToString("yyyy-MM-dd") + " додані успішно", "Успіх",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Рейси на " + dateTimePicker.Value.ToString("yyyy-MM-dd") + " вже були додані", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormActualFlightConf_Load(object sender, EventArgs e)
        {

        }
    }
}
