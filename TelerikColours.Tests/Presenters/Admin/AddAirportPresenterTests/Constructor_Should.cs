//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TelerikColours.Mvp.Admin.AddAirport;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddAirportPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceExceptionWithMessageContaining_ILocationService_WhenLicationServiceIsNull()
        {
            // Arrange
            var factoryServiceStub = new Mock<IFactoryService>();
            var viewStub = new Mock<IAddAirportView>();

            // Act and Assert
            Assert.That(
              () => new AddAirportPresenter(viewStub.Object, null, factoryServiceStub.Object),
              Throws.InstanceOf<NullReferenceException>().With.Message.Contains("ILocationService"));
        }

        [Test]
        public void ThrowNullReferenceExceptionWithMessageContaining_IFactoryService_WhenIFactoryServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<IAddAirportView>();
            var locationServiceStub = new Mock<ILocationService>();

            // Act and Assert
            Assert.That(
              () => new AddAirportPresenter(viewStub.Object, locationServiceStub.Object, null),
              Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFactoryService"));
        }

        [Test]
        public void NotThrow_WhenEveythingIsSet()
        {
            // Arrange
            var viewStub = new Mock<IAddAirportView>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var locationServiceStub = new Mock<ILocationService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new AddAirportPresenter(viewStub.Object, locationServiceStub.Object, factoryServiceStub.Object));
        }

    }
}

