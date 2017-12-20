using AirportData;
using System.Data.SqlClient;
using Xunit;

namespace AirportInfo.MyTest
{
    [Order(3)]
    public class CountryTests
    {
        public CountryTests()
        {
            Country.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
            //Country.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
        }
        [Fact]
        public void DeleteTest()
        {
            Country temp = new Country();
            temp.CountryCode = "jj";
            //Assert.Equal(temp.Delete(), true);
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            Assert.True(new Country().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            Country temp = new Country("jj","django");
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            Country temp = new Country("jj", "django1");
            Assert.True(temp.Update());
        }


    }
}
