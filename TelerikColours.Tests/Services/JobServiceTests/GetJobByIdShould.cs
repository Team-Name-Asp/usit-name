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
    public class GetJobByIdShould
    {
        [Test]
        public void ReturnCorrectResults_WhenCalled()
        {
            // Arrange
            var jobRepositoryStub = new Mock<IRepository<Job>>();
            var jobService = new JobService(jobRepositoryStub.Object);

            var searchedId = 1;

            var expectedJob = new Job() { Id = 1, JobTitle = "JobTitle1", JobDescription = "JobDescription1", CompanyName = "CompanyName1" };

            jobRepositoryStub.Setup(j => j.GetById(searchedId)).Returns(expectedJob);

            // Act
            var actualJob = jobService.GetJobById(searchedId);

            // Assert
            Assert.AreEqual(expectedJob, actualJob);
        }

    }
}
