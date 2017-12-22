using AirportData;
using System.Data.SqlClient;
using Xunit;

namespace AirportInfo.MyTest
{
    public class FlightTests
    {
        public FlightTests()
        {

            //Terminal.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            Flight.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            Flight temp = Flight.GetFlight("jjjjj");
            //Assert.Equal(temp.Delete(), true);
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            Assert.True(new Flight().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            Flight temp = new Flight("jjjjj");
            temp.Monday = true;
            temp.Tuesday = true;
            temp.Wednesday = true;
            temp.Thursday = false;
            temp.Friday = false;
            temp.Suterday = true;
            temp.Sunday = false;
            temp.DepartAirport = new Airport("aaa", "asdd", "as", "fdff");
            temp.ArriveAirport = new Airport("bbb", "asdd", "as", "fdff");
            temp.Company = new Company("ccc", "dsf", "as", "fdsgsg g f");
            temp.Plane = new Plane("aaa", "AAA", "120", "110", "1000 km");
            temp.DepartTime = "12:30";
            temp.ArriveTime = "14:15";
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            Flight temp = new Flight();
            temp.FlightCode = "jjjjj";
            temp.Monday = true;
            temp.Tuesday = true;
            temp.Wednesday = true;
            temp.Thursday = false;
            temp.Friday = false;
            temp.Suterday = true;
            temp.Sunday = false;
            temp.DepartAirport = new Airport("aaa", "asdd", "as", "fdff");
            temp.ArriveAirport = new Airport("bbf", "asdd", "as", "fdff");
            temp.Company = new Company("ccc", "dsf", "as", "fdsgsg g f");
            temp.Plane = new Plane("aaa", "AAA", "120", "110", "1000 km");
            temp.DepartTime = "12:30";
            temp.ArriveTime = "14:15";
            Assert.True(temp.Update());
        }
    }
}
