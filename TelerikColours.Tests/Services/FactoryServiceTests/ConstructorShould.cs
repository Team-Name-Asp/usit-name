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
    public class ConstructorShould
    {
        private Mock<IRepository<Country>> countryRepositry;
        private Mock<IRepository<Flight>> flightRepository;
        private Mock<IRepository<City>> cityRepository;
        private Mock<IRepository<Airport>> airportRepository;
        private Mock<IRepository<Airline>> airlineRepository;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<ILocationFactory> locationFactory;
        private Mock<IAirportFactory> airportFactory;

        [OneTimeSetUp]
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


        [Test]
        public void Throw_NulLReferenceException_With_CountryRepository_ContainingInMessage()
        {
            // Arrange
            string expectedMessageContains = "CountryRepository";

            // Act and Assert
            var actualMessage = Assert.Throws<NullReferenceException>(() => new FactoryService(null, cityRepository.Object, flightRepository.Object, airportRepository.Object, airlineRepository.Object, unitOfWork.Object, airportFactory.Object, locationFactory.Object)).Message;

            StringAssert.Contains(expectedMessageContains, actualMessage);
        }

        [Test]
        public void Throw_NulLReferenceException_With_CityRepository_ContainingInMessage()
        {
            // Arrange
            string expectedMessageContains = "CityRepository";

            // Act and Assert
            var actualMessage = Assert.Throws<NullReferenceException>(() => new FactoryService(countryRepositry.Object, null, flightRepository.Object, airportRepository.Object, airlineRepository.Object, unitOfWork.Object, airportFactory.Object, locationFactory.Object)).Message;

            StringAssert.Contains(expectedMessageContains, actualMessage);
        }

        [Test]
        public void Throw_NulLReferenceException_With_FlightRepository_ContainingInMessage()
        {
            // Arrange
            string expectedMessageContains = "FlightRepository";

            // Act and Assert
            var actualMessage = Assert.Throws<NullReferenceException>(() => new FactoryService(countryRepositry.Object, cityRepository.Object, null, airportRepository.Object, airlineRepository.Object, unitOfWork.Object, airportFactory.Object, locationFactory.Object)).Message;

            StringAssert.Contains(expectedMessageContains, actualMessage);
        }


        [Test]
        public void Throw_NulLReferenceException_With_AirportRepository_ContainingInMessage()
        {
            // Arrange
            string expectedMessageContains = "AirportRepository";

            // Act and Assert
            var actualMessage = Assert.Throws<NullReferenceException>(() => new FactoryService(countryRepositry.Object, cityRepository.Object, flightRepository.Object, null, airlineRepository.Object, unitOfWork.Object, airportFactory.Object, locationFactory.Object)).Message;

            StringAssert.Contains(expectedMessageContains, actualMessage);
        }

        [Test]
        public void Throw_NulLReferenceException_With_AirLineRepository_ContainingInMessage()
        {
            // Arrange
            string expectedMessageContains = "AirlineRepository";

            // Act and Assert
            var actualMessage = Assert.Throws<NullReferenceException>(() => new FactoryService(countryRepositry.Object, cityRepository.Object, flightRepository.Object, airportRepository.Object, null, unitOfWork.Object, airportFactory.Object, locationFactory.Object)).Message;

            StringAssert.Contains(expectedMessageContains, actualMessage);
        }

        [Test]
        public void Throw_NulLReferenceException_With_UnitOfWork_ContainingInMessage()
        {
            // Arrange
            string expectedMessageContains = "UnitOfWork";

            // Act and Assert
            var actualMessage = Assert.Throws<NullReferenceException>(() => new FactoryService(countryRepositry.Object, cityRepository.Object, flightRepository.Object, airportRepository.Object, airlineRepository.Object, null, airportFactory.Object, locationFactory.Object)).Message;

            StringAssert.Contains(expectedMessageContains, actualMessage);
        }

        [Test]
        public void Throw_NulLReferenceException_With_AirportFactory_ContainingInMessage()
        {
            // Arrange
            string expectedMessageContains = "AirportFactory";

            // Act and Assert
            var actualMessage = Assert.Throws<NullReferenceException>(() => new FactoryService(countryRepositry.Object, cityRepository.Object, flightRepository.Object, airportRepository.Object, airlineRepository.Object, unitOfWork.Object, null, locationFactory.Object)).Message;

            StringAssert.Contains(expectedMessageContains, actualMessage);
        }

        [Test]
        public void Throw_NulLReferenceException_With_LocationFactory_ContainingInMessage()
        {
            // Arrange
            string expectedMessageContains = "LocationFactory";

            // Act and Assert
            var actualMessage = Assert.Throws<NullReferenceException>(() => new FactoryService(countryRepositry.Object, cityRepository.Object, flightRepository.Object, airportRepository.Object, airlineRepository.Object, unitOfWork.Object, airportFactory.Object, null)).Message;

            StringAssert.Contains(expectedMessageContains, actualMessage);
        }
    }
}
