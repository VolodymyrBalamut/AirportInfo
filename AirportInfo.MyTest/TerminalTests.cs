using AirportData;
using System.Data.SqlClient;
using Xunit;

namespace AirportInfo.MyTest
{
    public class TerminalTests
    {
        public TerminalTests()
        {
            Terminal.conn = new SqlConnection("Server=(local)\\SQL2014;Database=master;User ID=sa;Password=Password12!");
            // Plane.conn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=master;User ID=sa;Password=1111");
        }
        [Fact]
        public void DeleteTest()
        {
            Terminal temp = new Terminal();
            temp.TerminalCode = "G";
            //Assert.Equal(temp.Delete(), true);
            Assert.True(temp.Delete());
        }

        [Fact]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            Assert.True(new Terminal().GetAll());
        }

        [Fact]
        public void InsertTest()
        {
            Terminal temp = new Terminal();
            temp.TerminalCode = "F";
            Assert.True(temp.Insert());
        }

        [Fact]
        public void UpdateTest()
        {
            Terminal temp = new Terminal();
            temp.TerminalCode = "G";
            temp.TerminalCodeOld = "F";
            Assert.True(temp.Update());
        }


    }
}
