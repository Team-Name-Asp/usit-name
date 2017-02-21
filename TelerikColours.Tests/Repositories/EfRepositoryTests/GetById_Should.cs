using Moq;
using NUnit.Framework;
using Repositories;
using System.Data.Entity;
using TelerikColours.Data.Contracts;
using TelerikColours.Tests.Repositories.Mocks;

namespace TelerikColours.Tests.Repositories.EfRepositoryTests
{
    [TestFixture]
    public class GetById_Should
    {
        [TestCase(2, 31)]
        [TestCase(12, 43)]
        public void CallFindOnDbSetWithExpectedId(int id, int secondId)
        {
            // Arrange
            var mockedDbContext = new Mock<IDbContext>();

            var mockedSet = new Mock<DbSet<Dummy>>();

            mockedDbContext.Setup(c => c.Set<Dummy>()).Returns(mockedSet.Object);

            var efRepository = new EfRepositoryMock<Dummy>(mockedDbContext.Object);

            // Act
            var actualItem = efRepository.GetById(id);

            // Assert
            mockedSet.Verify(s => s.Find(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void ReturnExpectedResult()
        {
            // Arrange
            var mockedDbContext = new Mock<IDbContext>();
            var mockedSet = new Mock<DbSet<Dummy>>();
            mockedDbContext.Setup(c => c.Set<Dummy>()).Returns(mockedSet.Object);
            var efRepository = new EfRepository<Dummy>(mockedDbContext.Object);

            var expectedDummy = new Dummy() { Id = It.IsAny<int>(), Name = It.IsAny<string>() };

            mockedSet.Setup(s => s.Find(It.IsAny<int>())).Returns(expectedDummy);

            // Act
            var actualDummy = efRepository.GetById(It.IsAny<int>());

            // Assert
            Assert.AreEqual(expectedDummy, actualDummy);
        }
    }
}
