using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
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
        private Mock<IRepository<Job>> jobRepository;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<ILocationFactory> locationFactory;
        private Mock<IAirportFactory> airportFactory;
        private Mock<IJobFactory> jobFactory;

        [SetUp]
        public void Init()
        {
            this.countryRepositry = new Mock<IRepository<Country>>();
            this.flightRepository = new Mock<IRepository<Flight>>();
            this.cityRepository = new Mock<IRepository<City>>();
            this.airportRepository = new Mock<IRepository<Airport>>();
            this.airlineRepository = new Mock<IRepository<Airline>>();
            this.jobRepository = new Mock<IRepository<Job>>();
            this.unitOfWork = new Mock<IUnitOfWork>();
            this.locationFactory = new Mock<ILocationFactory>();
            this.airportFactory = new Mock<IAirportFactory>();
            this.jobFactory = new Mock<IJobFactory>();
        }

        [TestCase(1, 3, 20, 303, 22)]
        [TestCase(12, 23, 220, 03, 44)]

        public void Call_CreateFlight_OnAirportFactory_WithProvidedParameter(int airportArrivalId, int airportDepartureId, decimal price, int airlineId, int availableSeats)
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object, this.jobRepository.Object, this.jobFactory.Object);

            DateTime departureDate = new DateTime(1999, 10, 10);
            DateTime arrivalDate = new DateTime(2002, 8, 10);

            // Act
            factoryService.AddFlight(airportArrivalId, airportDepartureId,  departureDate,  arrivalDate,  price,  airlineId, availableSeats);

            // Assert
            this.airportFactory.Verify(x => x.CreateFlight(
                It.Is<int>(aId => aId == airlineId),
                It.Is<int>(airArivId => airArivId == airportArrivalId),
                It.Is<int>(airAriDept => airAriDept == airportDepartureId),
                It.Is<DateTime>(arDate => arDate == arrivalDate),
                It.Is<DateTime>(departDate => departDate == departureDate),
                It.Is<decimal>(pr => pr == price),
                It.Is<int>(s => s == availableSeats)));
           
        }

        [Test]
        public void ShouddCall_Add_OnFlightRepository_WithExpectedFlight()
        { 
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object, this.jobRepository.Object, this.jobFactory.Object);

            var expectedFlight = new Mock<Flight>();
            this.airportFactory.Setup(x => x.CreateFlight(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>(), It.IsAny<int>())).Returns(expectedFlight.Object);

            // Act
            factoryService.AddFlight(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<int>());

            // Assert
            this.flightRepository.Verify(x => x.Add(It.Is<Flight>(f => f == expectedFlight.Object)));
        }

        [Test]
        public void Call_Commit_On_UnitOfWork_Once()
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object, this.jobRepository.Object, this.jobFactory.Object);

            // Act
            factoryService.AddCountry(It.IsAny<string>());

            // Assert
            this.unitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
