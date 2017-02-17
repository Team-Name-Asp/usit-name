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

namespace TelerikColours.Tests.Services.JobServiceTests
{
    [TestFixture]
    public class GetAllJobsShould
    {
        [Test]
        public void Call_IRepositoryOfJobs_Method_Method_GetAll_Once()
        {
            // Arrange
            var jobRepositoryStub = new Mock<IRepository<Job>>();
            var jobService = new JobService(jobRepositoryStub.Object);

            // Act
            jobService.GetAllJobs();

            // Assert
            jobRepositoryStub.Verify(j => j.GetAll(), Times.Once());
        }

        [Test]
        public void ReturnCorrectResults_WhenCalled()
        {
            // Arrange
            var jobRepositoryStub = new Mock<IRepository<Job>>();
            var expectedCollection = new List<Job>() { new Job { Id = 1, CompanyName = "Company 1" }, new Job { Id = 2, CompanyName = "Company2" } };
            jobRepositoryStub.Setup(j => j.GetAll()).Returns(expectedCollection);
            var jobService = new JobService(jobRepositoryStub.Object);

            // Act
            var actualCollection = jobService.GetAllJobs();

            // Assert
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }
    }
}
