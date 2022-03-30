using Entities.DTOs;
using Xunit;

namespace Business.Test.XUnit
{
    public class LocationManagerTestsXUnit
    {
        [Theory]
        [InlineData(new LocationEditDto
        {
            Id = 1,
            Name = "Ev5",
            Address = "Antalya5",
            TimeZonesId = 1,
            OpeningTime = new DateTime(1900, 1, 1, 10, 0, 0),
            ClosingTime = new DateTime(1900, 1, 1, 18, 0, 0)
        })]
        public void Test1()
        {

        }
    }
}