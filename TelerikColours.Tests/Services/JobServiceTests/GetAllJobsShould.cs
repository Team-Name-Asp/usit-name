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
    }
}
