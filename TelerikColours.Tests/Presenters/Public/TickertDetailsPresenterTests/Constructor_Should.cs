using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Public.TicketDetails;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.TickertDetailsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceExceptionWithMessageContainingUserService_WhenUserServiceIsNull()
        {
            // Arrange
            var ticketDetailsViewStub = new Mock<ITicketDetailsView>();

            // Act and Assert
            Assert.That(() => new TicketPresenter(ticketDetailsViewStub.Object, null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("UserService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Arrange
            var ticketDetailsViewStub = new Mock<ITicketDetailsView>();
            var userServiceStub = new Mock<IUserService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new TicketPresenter(ticketDetailsViewStub.Object, userServiceStub.Object));
        }
    }
}
