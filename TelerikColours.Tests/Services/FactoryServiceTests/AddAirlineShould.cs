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
    public class AddAirlineShould
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

    
        [TestCase("Airline 1")]
        [TestCase("Airline 2")]

        public void Call_CreateAirline_OnAirportFactory_WithProvidedParameter(string airlineName)
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object);

            // Act
            factoryService.AddAirline(airlineName);

            // Assert
            this.airportFactory.Verify(x => x.CreateAirline(It.Is<string>(par => par == airlineName)));
        }

        [Test]
        public void ShouddCall_Add_OnAirlineRepository_WithExpectedAirline()
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object);

            var expectedAirline = new Mock<Airline>();
            this.airportFactory.Setup(x => x.CreateAirline(It.IsAny<string>())).Returns(expectedAirline.Object);

            // Act
            factoryService.AddAirline(It.IsAny<string>());

            // Assert
            this.airlineRepository.Verify(x => x.Add(It.Is<Airline>(c => c == expectedAirline.Object)));
        }

        [Test]
        public void ShoudCall_Commit_On_UnitOfWork_Once()
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object);

            // Act
            factoryService.AddAirline(It.IsAny<string>());

            // Assert
            this.unitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
