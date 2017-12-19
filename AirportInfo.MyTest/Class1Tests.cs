using AirportData;
using Xunit;

namespace AirportInfo.MyTest
{
    public class Class1Tests
    {
        [Fact]
        public void PassingTest()
        {
            Plane plane = new Plane();
            Assert.Equal(plane.GetAll(), false);
        }
    }
}
