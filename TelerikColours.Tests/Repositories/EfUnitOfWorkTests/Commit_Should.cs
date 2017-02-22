using Moq;
using NUnit.Framework;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Data.Contracts;

namespace TelerikColours.Tests.Repositories.EfUnitOfWorkTests
{
    [TestFixture]
    public class Commit_Should
    {
        [Test]
        public void CallSaveChangesOnDbContext_WhenCommitIsCalled()
        {
            // Arrange
            var mockedDbContext = new Mock<IDbContext>();
            var efUnitOfWork = new EfUnitOfWork(mockedDbContext.Object);

            // Act
            efUnitOfWork.Commit();

            // Assert
            mockedDbContext.Verify(d => d.SaveChanges(), Times.Once);
        }
    }
}
