using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.TicketDetails;
using TelerikColours.Services.Contracts;
using TelerikColours.Services.Models;

namespace TelerikColours.Tests.Presenters.TickertDetailsPresenterTests
{
    [TestFixture]
    class View_BuyTIcket_Should
    {
        [Test]
        public void CallBuyTicketOnUserServiceWithExpectedParams_WhenBuyTicketEventIsRaised()
        {
            // Arrange
            var ticketDetailsViewStub = new Mock<ITicketDetailsView>();
            var userServiceMock = new Mock<IUserService>();
            var presenter = new TicketPresenter(ticketDetailsViewStub.Object, userServiceMock.Object);

            ticketDetailsViewStub.Setup(t => t.Model).Returns(new TicketDetailsViewModel());

            IEnumerable<PresentationFlight> expectedFlights = new List<PresentationFlight>()
            {
                new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(),It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>(), It.IsAny<string>()),
                 new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(),It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>(), It.IsAny<string>()),
                  new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(),It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>(), It.IsAny<string>())
            };

            var expectedUserId = "dasdasdsa8dsa8dsa";
            var eventArgs = new BuyTicketCustomEventArgs(expectedFlights, expectedUserId);

            bool isUserIdAsExpected = false;
            IEnumerable<PresentationFlight> actualFlights = null;
            userServiceMock.Setup(u => u.BuyTicket(It.IsAny<string>(), It.IsAny<IEnumerable<PresentationFlight>>())).Callback<string, IEnumerable<PresentationFlight>>((uId, flights) =>
           {
               if (uId == expectedUserId)
               {
                   isUserIdAsExpected = true;
               };

               actualFlights = flights;
           });

            // Act
            ticketDetailsViewStub.Raise(v => v.BuyTicket += null, eventArgs);

            // Assert

            Assert.IsTrue(isUserIdAsExpected);
            CollectionAssert.AreEqual(expectedFlights, actualFlights);
        }
    }
}

