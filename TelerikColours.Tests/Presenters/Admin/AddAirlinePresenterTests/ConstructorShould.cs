using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Admin.AddAirline;

namespace TelerikColours.Tests.Presenters.AddAirlinePresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Throw_NullReference_WithMessage_IFactoryService_When_FactoryServiceIsNull()
        {
            // Arrange
            var addAirlineViewStub = new Mock<IAddAirlineView>();
            string expectedMessage = "IFactoryService";

            // Act and assert
            var exception = Assert.Throws<NullReferenceException>(() => new AddAirlinePresenter(addAirlineViewStub.Object, null));

            StringAssert.Contains(expectedMessage, exception.Message);
        }
    }
}
