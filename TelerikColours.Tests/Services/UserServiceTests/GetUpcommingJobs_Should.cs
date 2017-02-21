using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;
using TelerikColours.Services.Utils;

namespace TelerikColours.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class GetUpcommingJobs_Should
    {
        [Test]
        public void ReturnExpectedCollectionOfUserWithPassedId_WhenPerformedExpectedExpressions()
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var userService = new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkStub.Object, airportFactoryStub.Object, ticketRepositoryStub.Object);

            var mockedDate = new DateTime(2016, 10, 10, 10, 5, 5, 3);
            var timeProvider = new Mock<TimeProvider>();

            timeProvider.Setup(x => x.GetDate()).Returns(mockedDate);
            TimeProvider.Current = timeProvider.Object;

            var firstDateOfDeparture = new DateTime(2016, 10, 10, 10, 5, 5, 1);
            var secondDateOfDeparture = new DateTime(2016, 10, 10, 11, 5, 5, 3);
            var thirdDateOfDeparture = new DateTime(2016, 10, 10, 12, 5, 5, 3);
            string userId = "GuidGuid";

            var jobs = new List<Job>()
            {
                new Job()
                {

                        StartDate = secondDateOfDeparture,
                    Id = It.IsAny<int>()
                },
                new Job()
                {

                        StartDate = thirdDateOfDeparture,
                    Id = It.IsAny<int>()
                },
                 new Job()
                {

                    StartDate = firstDateOfDeparture,
                    Id = It.IsAny<int>()
                }
            };

            var user = new ApplicationUser()
            {
                Id = userId,
                Jobs = jobs
            };

            var userCollection = new List<ApplicationUser>();
            userCollection.Add(user);

            var userCollectionAsQuaryable = userCollection.AsQueryable();

            userRepositoryStub.Setup(u => u.All).Returns(userCollectionAsQuaryable);


            var expectedCollection = userCollectionAsQuaryable.Where(u => u.Id == userId).SelectMany(p => p.Jobs).Where(f => f.StartDate > mockedDate).OrderBy(t => t.StartDate);

            // Act
            var actualCollection = userService.GetUpcommingJobs(userId);

            // Assert
            CollectionAssert.AreEqual(expectedCollection.ToList(), actualCollection.ToList());

            TimeProvider.ResetToDefault();
        }
    }
}
