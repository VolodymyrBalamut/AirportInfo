using AirportData.AirportModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirportInfo.MyTest
{
    public class ActualFlightHistoryTests
    {
        public ActualFlightHistoryTests()
        {

            //Terminal.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            ActualFlightHistory.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            ActualFlightHistory temp = new ActualFlightHistory("open", "close",DateTime.Now,1);
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            ActualFlightHistory temp = new ActualFlightHistory("ff", "dfdf", DateTime.Now, 1);
            temp.Insert();
            Assert.True(new ActualFlightHistory().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            ActualFlightHistory temp = new ActualFlightHistory("open", "close", DateTime.Now, 1);
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            ActualFlightHistory temp = new ActualFlightHistory("open", "close", DateTime.Now, 2);
            temp.ActualFlightHistoryID = 1;
            Assert.True(temp.Update());
        }
    }
}
