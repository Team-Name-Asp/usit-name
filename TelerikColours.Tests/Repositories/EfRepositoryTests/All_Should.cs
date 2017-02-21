using Moq;
using NUnit.Framework;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Data.Contracts;
using TelerikColours.Tests.Repositories.Mocks;

namespace TelerikColours.Tests.Repositories.EfRepositoryTests
{
    [TestFixture]
    public class All_Should
    {
        [Test]
        public void ReturnExpectedDbSet()
        {
            var mockedDbContext = new Mock<IDbContext>();

            var dbSetMock = QueryableDbSetMock.GetQueryableMockDbSet<Dummy>(new List<Dummy>() { new Dummy(), new Dummy() });

            mockedDbContext.Setup(c => c.Set<Dummy>()).Returns(dbSetMock);

            var efRepositoryMock = new EfRepository<Dummy>(mockedDbContext.Object);

            // Act
            var actual = efRepositoryMock.All;

            // Assert
            Assert.AreEqual(dbSetMock, actual);
        }
    }
}
