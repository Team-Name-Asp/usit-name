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
    public class ConstructorShould
    {
        [Test]
        public void Throw_WithExpectedMessage_When_IRepositoryOfJob_IsNull()
        {
            // Arrange
            string expectedContainingString = "JobRepository";

            // Act and Assert
            var output = Assert.Throws<NullReferenceException>(() => new JobService(null));

            StringAssert.Contains(expectedContainingString, output.Message);
        }
    }
}
