using Moq;
using NUnit.Framework;
using WeatherDataDal.Models;
using WeatherDataRetrieval;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace WeatherDataTest
{
    [TestFixture]
    public class GetWeatherDataTests
    {
        private MockRepository mockRepository;

        private Mock<WeatherDataContext> mockWeatherDataContext;
        private Mock<ILogger> mockLogger;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockWeatherDataContext = this.mockRepository.Create<WeatherDataContext>();
            this.mockLogger = this.mockRepository.Create<ILogger>();
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        //[Test]
        //public void Run_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var unitUnderTest = new GetWeatherData(mockWeatherDataContext, mockLogger);

        //    // Act
        //    var result = unitUnderTest.Run();

        //    // Assert
        //    if (!result)
        //        Assert.Fail();
        //    else
        //        Assert.IsTrue(result);
        //}
    }
}
