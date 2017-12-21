using AirportData;
using System.Data.SqlClient;
using Xunit;

namespace AirportInfo.MyTest
{
    public class StatusFlightTests
    {
        public StatusFlightTests()
        {

            //Terminal.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            StatusFlight.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            StatusFlight temp = new StatusFlight("open", "Open");
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            StatusFlight temp = new StatusFlight("close", "Close");
            temp.Insert();
            Assert.True(new UserRole().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            StatusFlight temp = new StatusFlight("open", "Open");
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            StatusFlight temp = new StatusFlight("open", "Open1");
            Assert.True(temp.Update());
        }
    }
}
