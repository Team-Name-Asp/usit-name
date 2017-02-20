using Moq;
using NUnit.Framework;
using Repositories;
using System;
using System.Collections.Generic;
using TelerikColours.Data.Contracts;
using TelerikColours.Tests.Repositories.Mocks;

namespace TelerikColours.Tests.Repositories.EfRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_NullReference_WithMessageContaining_DbContext()
        {
            Assert.That(
              () => new EfRepository<Dummy>(null),
               Throws.InstanceOf<NullReferenceException>().With.Message.Contains("DbContext"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsSet()
        {
            // Arrange
            var mockedDbContext = new Mock<IDbContext>();

            // Act and Assert
            Assert.DoesNotThrow(() => new EfRepository<Dummy>(mockedDbContext.Object));
        }

        //[Test]
        //public void SetDbSet_WithCorrectSet()
        //{
        //    // Arrange
        //    var mockedDbContext = new Mock<IDbContext>();
        //    var efRepository = new EfRepository<Dummy>(mockedDbContext.Object);

        //    var dbSetMock = QueryableDbSetMock.GetQueryableMockDbSet<Dummy>(new List<Dummy>() { new Dummy() });

        //    mockedDbContext.Setup(c => c.Set<Dummy>()).Returns(dbSetMock);
        //    // Act

        //}
    }
}

