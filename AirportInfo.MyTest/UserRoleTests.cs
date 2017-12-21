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
    public class UserRoleTests
    {
        public UserRoleTests()
        {

            //Terminal.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            UserRole.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            UserRole temp = new UserRole("admin", "Administration");
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            Assert.True(new UserRole().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            UserRole temp = new UserRole("admin", "Administration");
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            UserRole temp = new UserRole("admin", "Administration1");
            Assert.True(temp.Update());
        }
    }
}
