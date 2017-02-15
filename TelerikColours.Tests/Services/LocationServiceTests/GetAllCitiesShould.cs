using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System.Collections.Generic;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.LocationServiceTests
{
    [TestFixture]
    public class GetAllCitiesShould
    {
        [Test]
        public void ReturnExpectedCollection()
        {
            // Arrange
            var countryRepositoryStub = new Mock<IRepository<Country>>();
            var cityRepositoryMock = new Mock<IRepository<City>>();
            var locationService = new LocationService(countryRepositoryStub.Object, cityRepositoryMock.Object);

            var expectedCollection = new List<City> { new City() { Id = 1, Name = "First", CountryId = 1 }, new City() { Id = 2, Name = "I dont know", CountryId = 2 }, new City() { Id = 61, Name = "ATest", CountryId = 1 } };

            cityRepositoryMock.Setup(x => x.GetAll()).Returns(expectedCollection);

            // Act
            var actualCollection = locationService.GetAllCities();

            // Assert
            CollectionAssert.AreEquivalent(expectedCollection, actualCollection);
        }
    }
}
