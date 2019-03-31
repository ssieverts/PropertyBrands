using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using WeatherDataDal.Models;
using WeatherDataRetrieval;

namespace WeatherDataTest
{
    [TestFixture]
    public class GetWeatherDataTests
    {
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Default);

            mockLogger = mockRepository.Create<ILogger>();

            mockWeatherDataContext = new Mock<WeatherDataContext>();
            mockSet = new Mock<DbSet<WeatherData>>();
            mockWeatherDataContext.Setup(m => m.WeatherData).Returns(mockSet.Object);
        }

        [TearDown]
        public void TearDown()
        {
            mockRepository.VerifyAll();
        }

        private MockRepository mockRepository = new MockRepository(MockBehavior.Loose);
        private Mock<WeatherDataContext> mockWeatherDataContext;
        private Mock<DbSet<WeatherData>> mockSet;
        private Mock<ILogger> mockLogger;
        private readonly string[] forbidden = {"Failed"};

        [Test]
        public async Task Run_should_not_log_failure()
        {
            var logger = (ListLogger) TestFactory.CreateLogger(LoggerTypes.List);
            var getWeatherData = new GetWeatherData(null, logger);

            var result = await getWeatherData.Run();
            var msg = new List<string> {logger.Logs[0]};
            Assert.Contains("GetWeatherData - Run Started", msg);
            Assert.IsEmpty(msg.Intersect(forbidden));
        }
    }
}