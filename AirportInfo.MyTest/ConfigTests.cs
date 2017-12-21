using AirportData;
using AirportData.AirportModel;
using System.Data.SqlClient;
using Xunit;

namespace AirportInfo.MyTest
{
    public class ConfigTests
    {
        public ConfigTests()
        {

            //Terminal.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            Config.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            Config temp = new Config("admin", "Administration");
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            Assert.True(new Config().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            Config temp = new Config("admin", "Administration");
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            Config temp = new Config("admin", "Administration1");
            Assert.True(temp.Update());
        }
    }
}
