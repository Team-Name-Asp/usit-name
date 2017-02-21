using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Public.Home;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.HomePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullRefferenceExceptionWithMessageContainingIFlightService_WhenIFlightServiceIsNull()
        {
            // Arrange
            var homeViewStub = new Mock<IHomeView>();

            // Act and Assert
            Assert.That(() => new HomePresenter(homeViewStub.Object, null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFlightService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Arrange
            var homeViewStub = new Mock<IHomeView>();
            var flightServiceStub = new Mock<IFlightService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new HomePresenter(homeViewStub.Object, flightServiceStub.Object));
        }
    }
}
