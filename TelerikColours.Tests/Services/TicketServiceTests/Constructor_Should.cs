using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.TicketServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceExceptionWithMessageContainingTicketRepository_WhenTicketRepositoryIsNull()
        {
            // Arrange, Act and Assert
            Assert.That(() => new TicketService(null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("TicketRepository"));
        }

        [Test]
        public void NotThrow_WhenTicketRepositoryIsPassed()
        {
            // Arrange
            var ticketServiceStub = new Mock<IRepository<Ticket>>();

            // Act and Assert
            Assert.DoesNotThrow(() => new TicketService(ticketServiceStub.Object));
        }
    }
}
