using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;
using TelerikColours.Services.Utils;

namespace TelerikColours.Tests.Services.JobServiceTests
{
    [TestFixture]
    public class GetSoonestJobs_Should
    {
        [Test]
        public void ReturnExpectedCollection_WhenExpectedExpressionsArePerformedOnCollection()
        {
            // Arrange
            var jobRepositoryStub = new Mock<IRepository<Job>>();
            var jobService = new JobService(jobRepositoryStub.Object);

            var mockedDate = new DateTime(2016, 10, 10, 10, 5, 5, 3);
            var timeProvider = new Mock<TimeProvider>();

            timeProvider.Setup(x => x.GetDate()).Returns(mockedDate);
            TimeProvider.Current = timeProvider.Object;

            var dateAfter = new DateTime(2016, 10, 11, 10, 5, 5, 3);
            var secondDateAfter = new DateTime(2016, 10, 12, 10, 5, 5, 3);
            var dateBefore = new DateTime(2016, 5, 12, 10, 5, 5, 3);


            var jobs = new List<Job>()
            {
                new Job()
                {
                    StartDate = secondDateAfter,
                    Slots = 20
                },
                 new Job()
                {
                    StartDate = dateAfter,
                    Slots = 1
                },
                  new Job()
                {
                    StartDate = dateBefore,
                    Slots = 200
                },
            }.AsQueryable();

            jobRepositoryStub.Setup(f => f.All).Returns(jobs);

            var take = 3;

            var expectedJobs = jobs.Where(x => x.StartDate > mockedDate && x.Slots > 0).OrderBy(x => x.StartDate).Take(take).ToList();

            // Act
            var actualJobs = jobService.GetSoonestJobs();

            // Assert
            CollectionAssert.AreEqual(expectedJobs, actualJobs);
        }
    }
}
