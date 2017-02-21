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
            var jobServiceStub = new Mock<IJobService>();

            // Act and Assert
            Assert.That(() => new HomePresenter(homeViewStub.Object, null, jobServiceStub.Object), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFlightService"));
        }

        [Test]
        public void ThrowNullRefferenceExceptionWithMessageContainingIJobService_WhenIJobServiceIsNull()
        {
            // Arrange
            var homeViewStub = new Mock<IHomeView>();
            var mockedFlightService = new Mock<IFlightService>();

            // Act and Assert
            Assert.That(() => new HomePresenter(homeViewStub.Object, mockedFlightService.Object, null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IJobService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Arrange
            var homeViewStub = new Mock<IHomeView>();
            var flightServiceStub = new Mock<IFlightService>();
            var jobServiceStub = new Mock<IJobService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new HomePresenter(homeViewStub.Object, flightServiceStub.Object, jobServiceStub.Object));
        }
    }
}
