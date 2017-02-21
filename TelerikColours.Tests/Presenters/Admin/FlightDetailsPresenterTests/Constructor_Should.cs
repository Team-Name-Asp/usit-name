using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Admin.FlightDetails;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.FlightDetailsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceExceptionWithMessageContainingIFlightService_WhenIFlightServiceIsNull()
        {
            // Arrange
            var flightViewStub = new Mock<IFlightView>();

            // Act and Assert
            Assert.That(() =>
            new FlightDetailsPresenter(flightViewStub.Object, null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFlightService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsSet()
        {
            // Arrange
            var flightViewStub = new Mock<IFlightView>();
            var flightServiceStub = new Mock<IFlightService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new FlightDetailsPresenter(flightViewStub.Object, flightServiceStub.Object));
        }
    }
}
