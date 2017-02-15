using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System.Collections.Generic;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.AirlineServiceTests
{
    [TestFixture]
    public class GetAllAirportsInCityShould
    {
        [Test]
        public void ReturnExpectedCollection()
        {
            // Arrange
            var airlineRepositoryMock = new Mock<IRepository<Airline>>();
            var airlineService = new AirlineService(airlineRepositoryMock.Object);
            var expectedCollection = new List<Airline>() { new Airline("firstAirline"), new Airline("SecondAirline") };

            airlineRepositoryMock.Setup(x => x.GetAll()).Returns(expectedCollection);

            // Act
            var actualCollection = airlineService.GetAllAirlines();

            // Assert
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }
    }
}
