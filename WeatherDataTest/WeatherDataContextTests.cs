using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WeatherDataDal.Models;

namespace WeatherDataTest
{
    [TestFixture]
    public class WeatherDataContextTests
    {
        [SetUp]
        public void SetUp()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            weatherData = new List<WeatherData>
            {
                new WeatherData
                {
                    Id = 1,
                    Name = "Athens,GA"
                },
                new WeatherData
                {
                    Id = 2,
                    Name = "Athens,GA"
                },
                new WeatherData
                {
                    Id = 3,
                    Name = "Milton,GA"
                },
                new WeatherData
                {
                    Id = 4,
                    Name = "Alpharetta,GA"
                }
            }.AsQueryable();

            mockWeatherDataContext = new Mock<WeatherDataContext>();
            mockSet = new Mock<DbSet<WeatherData>>();
            mockWeatherDataContext.Setup(m => m.WeatherData).Returns(mockSet.Object);

            // Act - Add the data
            mockSet.Object.AddRange(weatherData);
            mockWeatherDataContext.Object.SaveChanges();

        }

        [TearDown]
        public void TearDown()
        {
            mockRepository.VerifyAll();
        }

        private readonly MockRepository mockRepository = new MockRepository(MockBehavior.Loose);
        private Mock<WeatherDataContext> mockWeatherDataContext;
        private Mock<DbSet<WeatherData>> mockSet;
        private IQueryable<WeatherData> weatherData;

        [Test]
        public void CreateWeatherDataTest()
        {
            // Assert
            // verify that a WeatherData item was added 4 times and
            // we saved our changes once.
            mockSet.Verify(m => m.Add(It.IsAny<WeatherData>()), Times.AtMost(4));
            mockWeatherDataContext.Verify(m => m.SaveChanges() , Times.Once);
        }

        [Test]
        public void GetWeatherDataTests()
        {
            // To query our database we need to implement IQueryable 
            mockSet.As<IQueryable<WeatherData>>().Setup(m => m.Provider).Returns(weatherData.Provider);
            mockSet.As<IQueryable<WeatherData>>().Setup(m => m.Expression).Returns(weatherData.Expression);
            mockSet.As<IQueryable<WeatherData>>().Setup(m => m.ElementType).Returns(weatherData.ElementType);
            mockSet.As<IQueryable<WeatherData>>().Setup(m => m.GetEnumerator()).Returns(weatherData.GetEnumerator());

            mockWeatherDataContext = new Mock<WeatherDataContext>();
            mockWeatherDataContext.Setup(c => c.WeatherData).Returns(mockSet.Object);

            // Asset
            // Ensure that 4 weatherData items are returned and
            // the first one's zip is 30606
            Assert.AreEqual(4, weatherData.Count());
            Assert.AreEqual("Athens,GA", weatherData.First().Name);
        }
    }
}