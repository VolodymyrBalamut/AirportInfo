using AirportData;
using System.Data.SqlClient;
using Xunit;

namespace AirportInfo.MyTest
{
    [Order(4)]
    public class PlaneTests
    {
        public PlaneTests()
        {
            Plane.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
            //Plane.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
        }  
        [Fact]
        public void DeleteTest()
        {
            Plane temp = new Plane();
            temp.PlaneCode = "aaa";
            //Assert.Equal(temp.Delete(), true);
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            Assert.True(new Plane().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            Plane temp = new Plane();
            temp.PlaneCode = "aaa";
            temp.PlaneName = "AAA";
            temp.Seats = "120";
            temp.Speed = "110";
            temp.Distance = "1000 km";
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            Plane temp = new Plane();
            temp.PlaneCode = "aaa";
            temp.PlaneName = "AAA";
            temp.Seats = "140";
            temp.Speed = "120";
            temp.Distance = "1000 km";
            Assert.True(temp.Update());
        }

    }
}
