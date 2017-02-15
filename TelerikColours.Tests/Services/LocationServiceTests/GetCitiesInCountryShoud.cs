using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.LocationServiceTests
{
    [TestFixture]
    public class GetCitiesInCountryShoud
    {
        [TestCase(1)]
        [TestCase(11)]
        public void Call_GetAllOfCityRepository_WithExpectedExpressions(int id)
        {
            // Arrange
            var countryRepositoryStub = new Mock<IRepository<Country>>().Object;
            var cityRepositoryMock = new Mock<IRepository<City>>();
            var locationService = new LocationService(countryRepositoryStub, cityRepositoryMock.Object);
            var expectedCollection = new List<City> { new City() { Id = 1, Name = "First", CountryId = 1 }, new City() { Id = 2, Name = "I dont know", CountryId = 2 }, new City() { Id = 61, Name = "ATest", CountryId = 1 } };

            Expression<Func<City, bool>> expectedFilter = x => x.CountryId == id;
            Expression<Func<City, string>> expectedSort = x => x.Name;

            Expression<Func<City, bool>> actual = null;
            Expression<Func<City, string>> sort = null;

            cityRepositoryMock.Setup(x => x.GetAll((It.IsAny<Expression<Func<City, bool>>>()), It.IsAny<Expression<Func<City, string>>>())).Callback<Expression<Func<City, bool>>, Expression<Func<City, string>>>((x, y) =>
            {
                actual = x;
                sort = y;
            });

            // Act
            locationService.GetCityInCountry(id);

            var actualCollection = expectedCollection.Where(x => actual.Compile()(x));

            actualCollection = actualCollection.OrderBy(x => sort.Compile()(x));

            var myExpectCollection = expectedCollection
                .Where(x => expectedFilter.Compile()(x))
                .OrderBy(x => x.Name);

            // Assert
            CollectionAssert.AreEqual(actualCollection, myExpectCollection);
        }

       [Test]
        public void Return_ExpectedCollection_InSameOrder()
        {
            // Arrange
            var countryRepositoryStub = new Mock<IRepository<Country>>().Object;
            var cityRepositoryMock = new Mock<IRepository<City>>();
            var locationService = new LocationService(countryRepositoryStub, cityRepositoryMock.Object);
            var expectedCollection = new List<City> { new City() { Id = 1, Name = "First", CountryId = 11 }, new City() { Id = 2, Name = "I dont know", CountryId = 21 }, new City() { Id = 61, Name = "ATest", CountryId = 21 } };

            cityRepositoryMock.Setup(x => x.GetAll((It.IsAny<Expression<Func<City, bool>>>()), It.IsAny<Expression<Func<City, string>>>())).Returns(expectedCollection);

            // Act
            var actualCollection  = locationService.GetCityInCountry(It.IsAny<int>());

            // Assert
            CollectionAssert.AreEqual(actualCollection, expectedCollection);
        }
    }
}

