using AirportData;
using System.Data.SqlClient;
using Xunit;

namespace AirportInfo.MyTest
{
    public class CompanyTests
    {
        public CompanyTests()
        {
            //Country.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            Company.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            Company temp = new Company();
            temp.CompanyCode = "jj";
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            Company temp = new Company("tt", "django", "dd", "dd");
            temp.Insert();
            Assert.True(new Company().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            Company temp = new Company("jj", "django","dd","dd");
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            Company temp = new Company("jj", "django1", "dd", "dd");
            Assert.True(temp.Update());
        }
    }
}
