using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Public.SearchFlight;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.SearchFlightPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReference_WithMessageContaining_IFlightService_When_IFlightServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ISearchFlightView>();
            var locationServiceStub = new Mock<ILocationService>();
            var airportServiceStub = new Mock<IAirportService>();
            // Act and Assert
            Assert.That(
               () => new SearchFlightPresenter(viewStub.Object, null, locationServiceStub.Object, airportServiceStub.Object),
               Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFlightService"));
        }

        [Test]
        public void ThrowNullReference_WithMessageContaining_ILocationService_When_ILocationServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ISearchFlightView>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();

            // Act and Assert
            Assert.That(
               () => new SearchFlightPresenter(viewStub.Object, flightServiceStub.Object, null, airportServiceStub.Object),
               Throws.InstanceOf<NullReferenceException>().With.Message.Contains("ILocationService"));
        }

        [Test]
        public void ThrowNullReference_WithMessageContaining_IAirportService_When_ILocationServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ISearchFlightView>();
            var flightServiceStub = new Mock<IFlightService>();
            var locationServiceStub = new Mock<ILocationService>();

            // Act and Assert
            Assert.That(
               () => new SearchFlightPresenter(viewStub.Object, flightServiceStub.Object, locationServiceStub.Object, null),
               Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IAirportService"));
        }
    }
}
