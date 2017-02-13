using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Public.SearchFlight;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.SearchFlightPresenterTests
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

            // Act and Assert
            Assert.That(
               () => new SearchFlightPresenter(viewStub.Object, null, locationServiceStub.Object),
               Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFlightService"));
        }

        [Test]
        public void ThrowNullReference_WithMessageContaining_ILocationService_When_ILocationServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ISearchFlightView>();
            var flightServiceStub = new Mock<IFlightService>();

            // Act and Assert
            Assert.That(
               () => new SearchFlightPresenter(viewStub.Object, flightServiceStub.Object, null),
               Throws.InstanceOf<NullReferenceException>().With.Message.Contains("ILocationService"));
        }
    }
}
