using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.TicketServiceTests
{
    [TestFixture]
    public class GetTicketSales_Should
    {
        [Test]
        public void ReturnExpectedCollection_AfterPerformedExpectedExpressions()
        {
            // Arrange
            var ticketRepoMock = new Mock<IRepository<Ticket>>();
            var ticketService = new TicketService(ticketRepoMock.Object);

            var startPeriod = new DateTime(2017, 10, 10);
            var firstBoughtDate = new DateTime(2017, 10, 12);
            var secondBoughtDate = new DateTime(2017, 11, 1);
            var endPeriod = new DateTime(2017, 11, 10);
            var thirdBoughtDate = new DateTime(2017, 11, 11);

            var appUser = new ApplicationUser()
            {
                Email = "asdd2@abv.asd"
            };

            var tickets = new List<Ticket>()
            {
                new Ticket()
                {
                    BoughtDate = firstBoughtDate,
                    ApplicationUser = appUser
                },
                 new Ticket()
                {
                    BoughtDate = secondBoughtDate,
                    ApplicationUser = appUser
                },
                  new Ticket()
                {
                    BoughtDate = endPeriod,
                    ApplicationUser = appUser
                },
                   new Ticket()
                {
                    BoughtDate = thirdBoughtDate,
                    ApplicationUser = appUser
                }
            }.AsQueryable();

            ticketRepoMock.Setup(t => t.All).Returns(tickets);

            var expectedTickets = tickets.Where(t => startPeriod <= t.BoughtDate && t.BoughtDate <= endPeriod).Include(t => t.ApplicationUser);

            // Act
            var actualCollection = ticketService.GetTicketSales(startPeriod, endPeriod);

            // Assert
            CollectionAssert.AreEqual(expectedTickets, actualCollection);
        }
    }
}
