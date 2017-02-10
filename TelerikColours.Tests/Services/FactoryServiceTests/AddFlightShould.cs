using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FactoryServiceTests
{
    [TestFixture]
    public class AddFlightShould
    {
        private Mock<IRepository<Country>> countryRepositry;
        private Mock<IRepository<Flight>> flightRepository;
        private Mock<IRepository<City>> cityRepository;
        private Mock<IRepository<Airport>> airportRepository;
        private Mock<IRepository<Airline>> airlineRepository;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<ILocationFactory> locationFactory;
        private Mock<IAirportFactory> airportFactory;

        [SetUp]
        public void Init()
        {
            this.countryRepositry = new Mock<IRepository<Country>>();
            this.flightRepository = new Mock<IRepository<Flight>>();
            this.cityRepository = new Mock<IRepository<City>>();
            this.airportRepository = new Mock<IRepository<Airport>>();
            this.airlineRepository = new Mock<IRepository<Airline>>();
            this.unitOfWork = new Mock<IUnitOfWork>();
            this.locationFactory = new Mock<ILocationFactory>();
            this.airportFactory = new Mock<IAirportFactory>();
        }

        [TestCase(1, 3, 20, 303)]
        [TestCase(12, 23, 220, 03)]

        public void Call_CreateFlight_OnAirportFactory_WithProvidedParameter(int airportArrivalId, int airportDepartureId, decimal price, int airlineId)
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object);

            DateTime departureDate = new DateTime(1999, 10, 10);
            DateTime arrivalDate = new DateTime(2002, 8, 10);

            // Act
            factoryService.AddFlight(airportArrivalId, airportDepartureId,  departureDate,  arrivalDate,  price,  airlineId);

            // Assert
            this.airportFactory.Verify(x => x.CreateFlight(
                It.Is<int>(airlId => airlId == airlineId),
                It.Is<int>(airportArId => airportArId == airportArrivalId),
                It.Is<int>(airDepartId => airDepartId == airportDepartureId),
                It.Is<DateTime>(departDate => departDate == departureDate),
                It.Is<DateTime>(arDate => arDate == arrivalDate),
                It.Is<decimal>(pr => pr == price)));
        }

        [Test]
        public void ShouddCall_Add_OnFlightRepository_WithExpectedFlight()
        { 
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object);

            var expectedFlight = new Mock<Flight>();
            this.airportFactory.Setup(x => x.CreateFlight(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>())).Returns(expectedFlight.Object);

            // Act
            factoryService.AddFlight(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>(), It.IsAny<int>());

            // Assert
            this.flightRepository.Verify(x => x.Add(It.Is<Flight>(f => f == expectedFlight.Object)));
        }

        [Test]
        public void Call_Commit_On_UnitOfWork_Once()
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object);

            // Act
            factoryService.AddCountry(It.IsAny<string>());

            // Assert
            this.unitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
