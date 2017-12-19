using AirportData;
using Xunit;

namespace AirportInfo.MyTest
{
    public class PlaneTests
    {
        [Fact]
        public void getPlaneName()
        {
            Plane plane = new Plane();
            plane.PlaneName = "A122";
            Assert.Equal(plane.getPlaneName(), "A122");
        }


    }
}
