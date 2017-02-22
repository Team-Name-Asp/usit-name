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
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceExceptionWithMessageContainingDbContext_WhenDbContextIsNull()
        {
            // Arrange, Act and Assert
            Assert.That(() =>
            new EfUnitOfWork(null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("DbContext"));
        }

        [Test]
        public void NotThrow_WhenDbContextIsPassed()
        {
            // Arrange
            var mockedDbContext = new Mock<IDbContext>();

            // Act and Assert
            Assert.DoesNotThrow(() => new EfUnitOfWork(mockedDbContext.Object));
        }
    }
}
