using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.Admin.AddFlight;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddFlightPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReferenceWithMessageContaining_ILocationService_WhenILocationServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ICreateFlightVliew>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            // Act and Assert
            Assert.That(
                () => new AddFlightPresenter(viewStub.Object, null, factoryServiceStub.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("ILocationService"));
        }

        [Test]
        public void ThrowNullReferenceWithMessageContaining_IFactoryService_WhenIFactoryServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            // Act and Assert
            Assert.That(
                () => new AddFlightPresenter(viewStub.Object, locationServiceStub.Object, null, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFactoryService"));
        }

        [Test]
        public void ThrowNullReferenceWithMessageContaining_IFlightService_WhenIFlightServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            // Act and Assert
            Assert.That(
                () => new AddFlightPresenter(viewStub.Object, locationServiceStub.Object, factoryServiceStub.Object, null, airportServiceStub.Object, airlineServiceStub.Object), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFlightService"));
        }

        [Test]
        public void ThrowNullReferenceWithMessageContaining_IAirportService_WhenIAirportServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            // Act and Assert
            Assert.That(
                () => new AddFlightPresenter(viewStub.Object, locationServiceStub.Object, factoryServiceStub.Object, flightServiceStub.Object, null, airlineServiceStub.Object), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IAirportService"));
        }

        [Test]
        public void ThrowNullReferenceWithMessageContaining_IAirlineService_WhenIAirlineServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();

            // Act and Assert
            Assert.That(
                () => new AddFlightPresenter(viewStub.Object, locationServiceStub.Object, factoryServiceStub.Object, flightServiceStub.Object, airportServiceStub.Object, null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IAirlineService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsSet()
        {
            // Arrange
            var viewStub = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new AddFlightPresenter(viewStub.Object, locationServiceStub.Object, factoryServiceStub.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object));
        }
    }
}
