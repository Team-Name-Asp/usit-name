using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Admin.TicketSales;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.TicketSalesPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceWithMessageCOntainingITIcketService_WhenITicheSeriviceIsNull()
        {
            // Arrange
            var ticketSalesViewStub = new Mock<ITicketsSalesView>();

            // Act and Assert
            Assert.That(() =>
            new TicketSalesPresenter(ticketSalesViewStub.Object, null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("ITicketService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsSet()
        {
            // Arrange
            var ticketSalesViewStub = new Mock<ITicketsSalesView>();
            var ticktServiceStub = new Mock<ITicketService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new TicketSalesPresenter(ticketSalesViewStub.Object, ticktServiceStub.Object));
        }
    }
}
