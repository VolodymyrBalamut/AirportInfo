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

        private void FormActualFlightConf_Load(object sender, EventArgs e)
        {
            ActualFlight aflight = new ActualFlight();
            Flight flight = new Flight();
            Company company = new Company();
            City city = new City();
            Country country = new Country("","");
            User user = new User();
            Terminal terminal = new Terminal();
            Airport airport = new Airport();
            Plane plane = new Plane();
            StatusFlight status = new StatusFlight();
            

        }
    }
}
