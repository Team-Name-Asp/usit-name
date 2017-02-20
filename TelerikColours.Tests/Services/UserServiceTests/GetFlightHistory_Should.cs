using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class GetFlightHistory_Should
    {
        [Test]
        public void ReturnSameCollection_WhenExpectedExpressionsAreExecutedOnIt()
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var userService = new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkStub.Object, airportFactoryStub.Object, ticketRepositoryStub.Object);

            var firstDateOfDeparture = new DateTime(2016, 10, 10, 10, 5, 5, 3);
            var secondDateOfDeparture = new DateTime(2016, 10, 10, 11, 5, 5, 3);
            var thirdDateOfDeparture  = new DateTime(2016, 10, 10, 12, 5, 5, 3);
            string userId = "GuidGuid";
            var ticketCollection = new List<Ticket>()
            {
                new Ticket()
                {
                    Flight = new Flight()
                    {
                        Id = It.IsAny<int>(),
                        DateOfDeparture = secondDateOfDeparture
                    },
                    Id = It.IsAny<int>()
                },
                new Ticket()
                {
                    Flight = new Flight()
                    {
                        Id = It.IsAny<int>(),
                        DateOfDeparture = thirdDateOfDeparture
                    },
                    Id = It.IsAny<int>()
                },
                 new Ticket()
                {
                    Flight = new Flight()
                    {
                        Id = It.IsAny<int>(),
                        DateOfDeparture = firstDateOfDeparture
                    },
                    Id = It.IsAny<int>()
                }
            };

            var user = new ApplicationUser()
            {
                Id = userId,
                Tickets = ticketCollection
            };

            var userCollection = new List<ApplicationUser>();
            userCollection.Add(user);

            var userCollectionAsQuaryable = userCollection.AsQueryable();

            userRepositoryStub.Setup(u => u.All).Returns(userCollectionAsQuaryable);


            var expectedCollection = userCollectionAsQuaryable.Where(u => u.Id == userId).SelectMany(p => p.Tickets).Select(t => t.Flight).OrderBy(t => t.DateOfDeparture);

            // Act
            var actualCollection = userService.GetFlightHistory(userId);

            // Assert
            CollectionAssert.AreEqual(expectedCollection.ToList(), actualCollection.ToList());
        }
    }
}
