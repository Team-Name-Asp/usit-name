using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TelerikColours.Mvp.Admin.AddJob;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddJobPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReferenceExceptionWithMessageContaining_IFactoryService_WhenIFactoryServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<IAddJobView>();
            var locationServiceStub = new Mock<ILocationService>();

            // Act and Assert
            Assert.That(
                () => new AddJobPresenter(viewStub.Object, null, locationServiceStub.Object), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFactoryService"));
        }

        [Test]
        public void ThrowNullReferenceExceptionWithMessageContaining_ILocationService_WhenILocationServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<IAddJobView>();
            var factoryServiceStub = new Mock<IFactoryService>();

            // Act and Assert
            Assert.That(
                () => new AddJobPresenter(viewStub.Object, factoryServiceStub.Object, null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("ILocationService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsSet()
        {
            // Arrange
            var viewStub = new Mock<IAddJobView>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceStub = new Mock<IFactoryService>();


            // Act and Assert
            Assert.DoesNotThrow(() => new AddJobPresenter(viewStub.Object, factoryServiceStub.Object, locationServiceStub.Object));
        }
    }
}
