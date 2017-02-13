using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FactoryServiceTests
{
    [TestFixture]
    public class AddCityShould
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


        [TestCase("Country 1", 1)]
        [TestCase("Country 2", 11)]

        public void Call_CreateCity_OnLocationFactory_WithProvidedParameters(string cityName, int countryId)
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object, this.jobRepository.Object, this.jobFactory.Object);

            // Act
            factoryService.AddCity(countryId, cityName);

            // Assert
            this.locationFactory.Verify(x => x.CreateCity(It.Is<string>(cName => cName == cityName), It.Is<int>(id => id == countryId)));
        }

        [Test]
        public void ShouddCall_Add_OnCountryRepository_WithExpectedCountry()
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object, this.jobRepository.Object, this.jobFactory.Object);

            var expectedCity = new Mock<City>();
            this.locationFactory.Setup(x => x.CreateCity(It.IsAny<string>(), It.IsAny<int>())).Returns(expectedCity.Object);
            // Act
            factoryService.AddCity(It.IsAny<int>(), It.IsAny<string>());

            // Assert
            this.cityRepository.Verify(x => x.Add(It.Is<City>(c => c == expectedCity.Object)));
        }

        [Test]
        public void ShoudCall_Commit_On_UnitOfWork_Once()
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object, this.jobRepository.Object, this.jobFactory.Object);

            // Act
            factoryService.AddCity(It.IsAny<int>(), It.IsAny<string>());

            // Assert
            this.unitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
