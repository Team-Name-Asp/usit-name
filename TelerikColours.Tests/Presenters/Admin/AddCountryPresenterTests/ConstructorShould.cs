using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.Admin.AddCountry;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddCountryPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReferenceExceptionWithMessageContainingIFactoryService_WhenIFactoryServiceIsNull()
        {
            // Arrange
            var stubbedView = new Mock<IAddCountryView>();

            // Act and Assert
            Assert.That(
           () => new AddCountryPresenter(stubbedView.Object, null),
           Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IFactoryService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsSet()
        {
            // Arrange
            var stubbedView = new Mock<IAddCountryView>();
            var stubbedFactoryService = new Mock<IFactoryService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new AddCountryPresenter(stubbedView.Object, stubbedFactoryService.Object));
        }
    }
}
