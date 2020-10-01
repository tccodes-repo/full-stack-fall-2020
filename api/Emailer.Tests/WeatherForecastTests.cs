using NUnit.Framework;
using FluentAssertions;

namespace Emailer
{
    [TestFixture]
    public class WeatherForecastTests
    {

        [Test]
        public void Setting_Summary_Should_Work()
        {
            new WeatherForecast {Summary = "123"}.Summary.Should().Be("123");
        }
        
    }
}