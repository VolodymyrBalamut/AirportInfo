using AirportData;
using System.Data.SqlClient;
using Xunit;

namespace AirportInfo.MyTest
{
    public class CityTests
    {
        public CityTests()
        {

            //Terminal.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            City.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            City temp = new City();
            temp.setNewCity("UA","Kiev");
            //Assert.Equal(temp.Delete(), true);
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            City temp = new City();
            temp.setNewCity("ff", "dfdg");
            temp.Insert();
            Assert.True(new City().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            City temp = new City();
            temp.setNewCity("UA", "Kyiv");
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            City temp = new City();
            temp.setOldCity("UA", "Kyiv");
            temp.setNewCity("UA", "Kiev");
            Assert.True(temp.Update());
        }
    }
}
