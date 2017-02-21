using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TelerikColours.Data.Contracts;
using TelerikColours.Tests.Repositories.Mocks;

namespace TelerikColours.Tests.Repositories.EfRepositoryTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnDbSetAsEnumerable_WhenParamsAreNotPassed()
        {
            var mockedDbContext = new Mock<IDbContext>();

            var dbSetMock = QueryableDbSetMock.GetQueryableMockDbSet<Dummy>(new List<Dummy>() { new Dummy(), new Dummy() });

            mockedDbContext.Setup(c => c.Set<Dummy>()).Returns(dbSetMock);

            var efRepositoryMock = new EfRepositoryMock<Dummy>(mockedDbContext.Object);

            // Act
            var actual = efRepositoryMock.GetAll();

            // Assert
            Assert.AreEqual(dbSetMock.ToList(), actual);
        }

        [TestCase("FirstName")]
        [TestCase("SecondName")]
        public void ReturnExpectedFilteredCollection(string name)
        {
            // Arrange
            var mockedDbContext = new Mock<IDbContext>();

            var dbSetMock = QueryableDbSetMock.GetQueryableMockDbSet<Dummy>(new List<Dummy>() { new Dummy() { Name = "FirstName" }, new Dummy() { Name = "SecondName" }, new Dummy() { Name = "FirstName" }});

            mockedDbContext.Setup(c => c.Set<Dummy>()).Returns(dbSetMock);

            var efRepositoryMock = new EfRepositoryMock<Dummy>(mockedDbContext.Object);

            var expectedResult = dbSetMock.Where(x => x.Name == name).ToList();

            // Act
            var actual = efRepositoryMock.GetAll(x => x.Name == name);

            // Assert
            CollectionAssert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void ReturnSortedCollection_WhenSortExpressionIsPassed()
        {
            var mockedDbContext = new Mock<IDbContext>();

            var dbSetMock = QueryableDbSetMock.GetQueryableMockDbSet<Dummy>(new List<Dummy>() { new Dummy() { Name = "FirstName" }, new Dummy() { Name = "SecondName" }, new Dummy() { Name = "FirstName" } });

            mockedDbContext.Setup(c => c.Set<Dummy>()).Returns(dbSetMock);

            var efRepositoryMock = new EfRepositoryMock<Dummy>(mockedDbContext.Object);

            var expectedResult = dbSetMock.OrderBy(x => x.Name).ToList();

            // Act
            var actual = efRepositoryMock.GetAll(null, x => x.Name);

            // Assert
            CollectionAssert.AreEqual(expectedResult, actual);
        }

        [TestCase(2)]
        [TestCase(3)]
        public void ReturnFilteredAndSortedCollection_WhenFilterAndSortExpressionArePassed(int id)
        {
            var mockedDbContext = new Mock<IDbContext>();

            var dbSetMock = QueryableDbSetMock.GetQueryableMockDbSet<Dummy>(new List<Dummy>() {
                new Dummy() { Name = "FirstName", Id = 2 },
                new Dummy() { Name = "SecondName", Id =2 },
                new Dummy() { Name = "FirstName" , Id = 3},
                new Dummy() { Name = "ZZZZZ", Id = 2 }
            });

            mockedDbContext.Setup(c => c.Set<Dummy>()).Returns(dbSetMock);

            var efRepositoryMock = new EfRepositoryMock<Dummy>(mockedDbContext.Object);

            var expectedResult = dbSetMock.Where(x => x.Id == id).OrderBy(x => x.Name).ToList();

            // Act
            var actual = efRepositoryMock.GetAll(x => x.Id == id, x => x.Name);

            // Assert
            CollectionAssert.AreEqual(expectedResult, actual);
        }

        [TestCase(2)]
        [TestCase(3)]
        public void ReturnFilteredAndProjectedColection_WhenFilterAndSelectExpressionArePassed(int id)
        {
            var mockedDbContext = new Mock<IDbContext>();

            var dbSetMock = QueryableDbSetMock.GetQueryableMockDbSet<Dummy>(new List<Dummy>() {
                new Dummy() { Name = "FirstName", Id = 2 },
                new Dummy() { Name = "SecondName", Id =2 },
                new Dummy() { Name = "FirstName" , Id = 3},
                new Dummy() { Name = "ZZZZZ", Id = 2 }
            });

            mockedDbContext.Setup(c => c.Set<Dummy>()).Returns(dbSetMock);

            var efRepositoryMock = new EfRepositoryMock<Dummy>(mockedDbContext.Object);

            var expectedCollection = dbSetMock.Where(x => x.Id == id).Select(x => x.Name);

            // Act
            var actual = efRepositoryMock.GetAll<Dummy, string>(x => x.Id == id, null, x => x.Name);

            // Assert
            CollectionAssert.AreEqual(expectedCollection, actual);
        }
    }
}
