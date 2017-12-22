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
    public class UserTests
    {
        public UserTests()
        {

            //Terminal.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            User.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            User temp = new User("admin1", "1111", "admin");
            temp.UserID = 1;
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            User temp = new User("admin2", "11111", "admin2");
            bool flag = temp.Insert();
            Assert.True(new User().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            User temp = new User("admin", "1111", "admin");
            bool flag = temp.Insert();
            User.getUser("admin", "1111");
            Assert.True(flag);
        }

        [Fact]
        public void UpdateTest()
        {
            User temp = new User("admin1", "1111", "admin");
            Assert.True(temp.Update());
        }
    }
}
