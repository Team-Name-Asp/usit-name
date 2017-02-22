using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FlightServiceTests
{
    [TestFixture]
    public class GetDetailedFlight_Should
    {
        [TestCase(23)]
        [TestCase(6)]
        public void ReturnExpectedFlightFromFlightRepositoryGetById_WhenIsCalledWithExpectedId(int id)
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkStub.Object, flightRepositoryStub.Object, cityRepositoryStub.Object, mappedFactory.Object);

            var flight = new Flight()
            {
                Id = id
            };

            flightRepositoryStub.Setup(f => f.GetById(id)).Returns(flight);

            // Act
            var actualFlight = flightService.GetDetailedFlight(id);

            // Assert
            Assert.AreEqual(flight, actualFlight);
        }
    }
}
