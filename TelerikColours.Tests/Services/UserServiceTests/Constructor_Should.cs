using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceExcepetion_WithMessageContainingFlightRepository_WhenFlightRepositoryIsNull()
        {
            // Arrange
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();

            // Act and Assert
            Assert.That(
                () => new UserService(userRepositoryStub.Object, null, unitOfWorkStub.Object, airportFactoryStub.Object, ticketRepositoryStub.Object),
             Throws.InstanceOf<NullReferenceException>().With.Message.Contains("FlightRepository"));
        }

        [Test]
        public void ThrowNullReferenceExcepetion_WithMessageContainingUserRepository_WhenUserRepositoryIsNull()
        {
            // Arrange
            var flightRepository = new Mock<IRepository<Flight>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();

            // Act and Assert
            Assert.That(
                () => new UserService(null, flightRepository.Object, unitOfWorkStub.Object, airportFactoryStub.Object, ticketRepositoryStub.Object),
             Throws.InstanceOf<NullReferenceException>().With.Message.Contains("UserRepository"));
        }

        [Test]
        public void ThrowNullReferenceExcepetion_WithMessageContainingUnitOfWork_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();

            // Act and Assert
            Assert.That(
                () => new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, null, airportFactoryStub.Object, ticketRepositoryStub.Object),
             Throws.InstanceOf<NullReferenceException>().With.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowNullReferenceExcepetion_WithMessageContainingIAirportFactory_WhenAirportFactoryIsNull()
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            // Act and Assert
            Assert.That(
                () => new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkStub.Object, null, ticketRepositoryStub.Object),
             Throws.InstanceOf<NullReferenceException>().With.Message.Contains("AirportFactory"));
        }

        [Test]
        public void ThrowNullReferenceExcepetion_WithMessageContainingTicketRepository_WhenTicketRepositoryIsNull()
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();

            // Act and Assert
            Assert.That(
                () => new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkStub.Object, airportFactoryStub.Object, null),
             Throws.InstanceOf<NullReferenceException>().With.Message.Contains("TicketRepository"));
        }

        [Test]
        public void NotThrow_WhenEverithingIsSet()
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();

            // Act and Assert
            Assert.DoesNotThrow(() => new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkStub.Object, airportFactoryStub.Object, ticketRepositoryStub.Object));
        }
    }
}
