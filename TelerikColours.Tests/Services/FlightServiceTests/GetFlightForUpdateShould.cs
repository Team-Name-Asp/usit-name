using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System.Collections.Generic;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FlightServiceTests
{
    [TestFixture]
    public class GetFlightForUpdateShould
    {
        [TestCase(1)]
        [TestCase(13)]
        public void GetById_On_FlightRepository_WithExpectedParameter(int id)
        {
            // Arrange
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var flightRepositoryMock = new Mock<IRepository<Flight>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkStub.Object, flightRepositoryMock.Object, cityRepositoryStub.Object, mappedFactory.Object);

            // Act
            flightService.GetFlightForUpdate(id);

            // Assert
            flightRepositoryMock.Verify(x => x.GetById(It.Is<int>(fId => fId == id)), Times.Once);
        }

        public void Return_Flight_ReturnedFromFlightRepository()
        {
            // Arrange
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var flightRepositoryMock = new Mock<IRepository<Flight>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkStub.Object, flightRepositoryMock.Object, cityRepositoryStub.Object, mappedFactory.Object);

            var expectedFlight = new Flight();
            flightRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(expectedFlight);

            // Act
            var actualFlight = flightService.GetFlightForUpdate(It.IsAny<int>());

            // Assert
            Assert.AreEqual(expectedFlight, actualFlight);
        }
    }
}
