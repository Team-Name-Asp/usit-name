using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TelerikColours.Mvp.Admin.TicketSales;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.TicketSalesPresenterTests
{
    [TestFixture]
    public class View_InitTickets_Should
    {
        [Test]
        public void SetTicketsOnViewModelWithExpectedCollection_WhenInitTicketsEventIsRaised()
        {
            // Arrange
            var ticketSalesViewMock = new Mock<ITicketsSalesView>();
            var ticktServiceStub = new Mock<ITicketService>();
            var ticketSalesPresenter = new TicketSalesPresenter(ticketSalesViewMock.Object, ticktServiceStub.Object);

            ticketSalesViewMock.Setup(v => v.Model).Returns(new TicketSalesViewModel());

            var startPeriod = new DateTime(2016, 10, 10);
            var endPeriod = new DateTime(2017, 10, 10);

            var expectedTickets = new List<Ticket>()
            {
                new Ticket(),
                new Ticket()
            }.AsQueryable();

            ticktServiceStub.Setup(s => s.GetTicketSales(startPeriod, endPeriod)).Returns(expectedTickets);

            var ticketsEventArgs = new TicketSalesCustomEventArgs(startPeriod, endPeriod);
            // Act
            ticketSalesViewMock.Raise(v => v.InitTickets += null, ticketsEventArgs);

            // Assert
            CollectionAssert.AreEquivalent(expectedTickets, ticketSalesViewMock.Object.Model.Tickets);
        }
    }
}
