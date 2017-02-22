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
    public class GetAllJobsFromByTerm_Should
    {
        [Test]
        public void ReturnCorrectResultsAlphabetically_WhenCalled()
        {
            // Arrange
            var stubbedRepository = new Mock<IRepository<Job>>();
            var jobService = new JobService(stubbedRepository.Object);
            var searchedTerm = "a";

            var expectedCollection = new List<Job>()
            {
                new Job() {JobTitle = "aa", JobDescription = "aa", CompanyName = "aa"},
                new Job() {JobTitle= "ba", JobDescription = "ab", CompanyName = "ab" },
                new Job() {JobTitle = "ca", JobDescription = "ac", CompanyName = "a" }
            }.AsQueryable();

            stubbedRepository.Setup(s => s.All).Returns(expectedCollection);

            // Act
            var actualCollection = jobService.GetAllJobsFromByTerm(searchedTerm);

            // Assert
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }
    }
}
