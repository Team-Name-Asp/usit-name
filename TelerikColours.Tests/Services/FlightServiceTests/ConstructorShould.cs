using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FlightServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Throw_NullReference_WithMessageContaining_AirportRepository()
        {
            // Arrange
           // var airlineRepositoryStub = new Mock<IRepository<Airline>>();
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            string expectedMessage = "AirportRepository";

            // Act and Assert
            var exception = Assert.Throws<NullReferenceException>(() => new FlightService(null, unitOfWorkStub.Object,  flightRepositoryStub.Object, cityRepositoryStub.Object, mappedFactory.Object));

            StringAssert.Contains(expectedMessage, exception.Message);
        }

        [Test]
        public void Throw_NullReference_WithMessageContaining_MappedFactory()
        {
            // Arrange
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            // var airlineRepositoryStub = new Mock<IRepository<Airline>>();
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            string expectedMessage = "MappedFactory";

            // Act and Assert
            var exception = Assert.Throws<NullReferenceException>(() => new FlightService(airportRepositoryStub.Object, unitOfWorkStub.Object, flightRepositoryStub.Object, cityRepositoryStub.Object, null));

            StringAssert.Contains(expectedMessage, exception.Message);

        }

        [Test]
        public void Throw_NullReference_WithMessageContaining_FlightRepository()
        {
            // Arrange
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var mappedFactory = new Mock<IMappedClassFactory>();

            string expectedMessage = "FlightRepository";

            // Act and Assert
            var exception = Assert.Throws<NullReferenceException>(() => new FlightService(airportRepositoryStub.Object, unitOfWorkStub.Object, null, cityRepositoryStub.Object, mappedFactory.Object));

            StringAssert.Contains(expectedMessage, exception.Message);
        }

      
        [Test]
        public void Throw_NullReference_WithMessageContaining_UnitOfWork()
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            string expectedMessage = "UnitOfWork";

            // Act and Assert
            var exception = Assert.Throws<NullReferenceException>(() => new FlightService(airportRepositoryStub.Object, null, flightRepositoryStub.Object, cityRepositoryStub.Object, mappedFactory.Object));

            StringAssert.Contains(expectedMessage, exception.Message);
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            // Act and Assert
            Assert.DoesNotThrow(() => new FlightService(airportRepositoryStub.Object, unitOfWorkStub.Object, flightRepositoryStub.Object, cityRepositoryStub.Object, mappedFactory.Object));
        }
    }
}
