using AirportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirportInfo.MyTest
{
    public class AirportTests
    {
        [Fact, Order(4)]
        public void DeleteTest()
        {
            Airport temp = new Airport();
            temp.AirportCode = "jjj";
            //Assert.Equal(temp.Delete(), true);
            Assert.True(temp.Delete());
        }

        [Fact, Order(3)]
        public void GetAllTest()
        {
            //Assert.Equal(new Terminal().GetAll(), true);
            Assert.True(new Airport().GetAll());
        }

        [Fact, Order(1)]
        public void InsertTest()
        {
            Airport temp = new Airport("jjj","ff","UA","Kiev");
            Assert.True(temp.Insert());
        }

        [Fact, Order(2)]
        public void UpdateTest()
        {
            Airport temp = new Airport("jjj", "fdf", "UA", "Kiev");
            Assert.True(temp.Update());
        }


    }
}
