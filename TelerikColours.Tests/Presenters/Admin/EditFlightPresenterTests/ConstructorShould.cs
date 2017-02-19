using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Admin.EditFlight;

namespace TelerikColours.Tests.Presenters.EditFlightPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReference_WithMessageContaining_IFlightService_WhenIFlightServiceIsNull()
        {
            // Arrange
            var stubbedView = new Mock<IEditFlightView>();
            var expected = "IFlightService";

            // Act and Assert
            var exception = Assert.Throws<NullReferenceException>(() => new EditFlightPresenter(stubbedView.Object, null));

            StringAssert.Contains(expected, exception.Message);
        }
}
}
