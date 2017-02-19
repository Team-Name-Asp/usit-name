using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Admin.AddCity;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddCityPresenterTests
{
    [TestFixture]
    class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceWithMessageContainingIFactoryService_WhenIFactoryServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<IAddCityView>();
            var locationServiceStub = new Mock<ILocationService>();

            // Act and Assert
            Assert.That(
              () => new AddCityPresenter(viewStub.Object, null, locationServiceStub.Object),
              Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFactoryService"));
        }

        [Test]
        public void ThrowNullReferenceWithMessageContainingILocationService_WhenILocationServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<IAddCityView>();
            var factoryServiceStub = new Mock<IFactoryService>();

            // Act and Assert
            Assert.That(
              () => new AddCityPresenter(viewStub.Object, factoryServiceStub.Object, null),
              Throws.InstanceOf<NullReferenceException>().With.Message.Contains("ILocationService"));
        }

        [Test]
        public void DoesNotThrow_WhenEverythingIsSet()
        {
            // Arrange
            var viewStub = new Mock<IAddCityView>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var locationServiceStub = new Mock<ILocationService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new AddCityPresenter(viewStub.Object, factoryServiceStub.Object, locationServiceStub.Object));
        }
    }
}