using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FactoryServiceTests
{
    [TestFixture]
    public class AddAirportShould
    {
        [TestFixture]
        public class AddCountryShould
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


            [TestCase(2, "Airport 1")]
            [TestCase(31, "Airport 2")]

            public void Call_CreateAirport_OnAirportFactory_WithProvidedParameters(int cityId, string airportName)
            {
                // Arrange
                var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object);

                // Act
                factoryService.AddAirport(cityId, airportName);

                // Assert
                this.airportFactory.Verify(x => x.CreateAirport(It.Is<string>(par => par == airportName), It.Is<int>(id => id == cityId)));
            }

            [Test]
            public void ShouddCall_Add_OnAirportRepository_WithExpectedAirport()
            {
                // Arrange
                var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object);

                var expectedAirport = new Mock<Airport>();
                this.airportFactory.Setup(x => x.CreateAirport(It.IsAny<string>(), It.IsAny<int>())).Returns(expectedAirport.Object);

                // Act
                factoryService.AddAirport(It.IsAny<int>(), It.IsAny<string>());

                // Assert
                this.airportRepository.Verify(x => x.Add(It.Is<Airport>(c => c == expectedAirport.Object)));
            }

            [Test]
            public void ShoudCall_Commit_On_UnitOfWork_Once()
            {
                // Arrange
                var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object);

                // Act
                factoryService.AddAirport(It.IsAny<int>(), It.IsAny<string>());

                // Assert
                this.unitOfWork.Verify(x => x.Commit(), Times.Once);
            }
        }
    }
}

