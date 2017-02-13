using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FactoryServiceTests
{
    [TestFixture]
    public class AddCountryShould
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


        [TestCase("Country 1")]
        [TestCase("Country 2")]

        public void Call_CreateCountry_OnLocationFactory_WithProvidedParameter(string countryName)
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object, this.jobRepository.Object, this.jobFactory.Object);

            // Act
            factoryService.AddCountry(countryName);

            // Assert
            this.locationFactory.Verify(x => x.CreateCountry(It.Is<string>(par => par == countryName)));
        }

        [Test]
        public void ShouddCall_Add_OnCountryRepository_WithExpectedCountry()
        {
            // Arrange
            var factoryService = new FactoryService(this.countryRepositry.Object, this.cityRepository.Object, this.flightRepository.Object, this.airportRepository.Object, this.airlineRepository.Object, this.unitOfWork.Object, this.airportFactory.Object, this.locationFactory.Object, this.jobRepository.Object, this.jobFactory.Object);

            var expectedCountry = new Mock<Country>();
            this.locationFactory.Setup(x => x.CreateCountry(It.IsAny<string>())).Returns(expectedCountry.Object);
            // Act
            factoryService.AddCountry(It.IsAny<string>());

            // Assert
            this.countryRepositry.Verify(x => x.Add(It.Is<Country>(c => c == expectedCountry.Object)));
        }

        [Test]
        public void ShoudCall_Commit_On_UnitOfWork_Once()
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
