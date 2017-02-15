using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FlightServiceTests
{
    [TestFixture]
    public class SaveUpdatedFlightShould
    {
        [Test]
        public void Call_Commit_OnUnitOfWorm_Once()
        {
            // Arrange
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var flightRepositoryMock = new Mock<IRepository<Flight>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkMock.Object, flightRepositoryMock.Object, cityRepositoryStub.Object, mappedFactory.Object);

            // Act
            flightService.SaveUpdatedFlight();

            // Assert
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }
    }
}
