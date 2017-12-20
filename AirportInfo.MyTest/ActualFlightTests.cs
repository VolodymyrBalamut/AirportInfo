using AirportData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirportInfo.MyTest
{
    public class ActualFlightTests
    {
        public ActualFlightTests()
        {

            //Terminal.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            ActualFlight.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            ActualFlight temp = new ActualFlight();
            temp.ActualFlightID = 1;
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            Assert.True(new ActualFlight().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            ActualFlight temp = new ActualFlight();
            temp.ActualFlightDate = DateTime.Now;
            temp.Flight = new Flight("sdsfd");
            temp.Plane = new Plane("ass","dsd","dsd","sdsd","sds");
            temp.Terminal = new Terminal("A");
            temp.StatusFlight = new StatusFlight("open","Open");
            temp.TimeDifference = 0;
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            ActualFlight temp = new ActualFlight();
            temp.ActualFlightDate = DateTime.Now;
            temp.Flight = new Flight("sdsfd");
            temp.Plane = new Plane("ass", "dsd", "dsd", "sdsd", "sds");
            temp.Terminal = new Terminal("B");
            temp.StatusFlight = new StatusFlight("open", "Open");
            temp.TimeDifference = 0;
            Assert.True(temp.Update());
        }
    }
}
