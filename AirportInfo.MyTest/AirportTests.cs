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
    public class AirportTests
    {
        public AirportTests()
        {
            
            // Airport.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
            CreateTables.createTables();
            Airport.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
        }
        [Fact]
        public void DeleteTest()
        {
            Airport temp = new Airport();
            temp.AirportCode = "jjj";
            //Assert.Equal(temp.Delete(), true);
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            Assert.True(new Airport().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            Airport temp = new Airport("jjj","ff","UA","Kiev");
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            Airport temp = new Airport("jjj", "fdf", "UA", "Kiev");
            Assert.True(temp.Update());
        }


    }
}
