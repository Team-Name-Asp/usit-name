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
        public void Return_ExpectedCollectionOfCities(int id)
        {
            // Arrange
            var countryRepositoryStub = new Mock<IRepository<Country>>().Object;
            var cityRepositoryMock = new Mock<IRepository<City>>();
            var locationService = new LocationService(countryRepositoryStub, cityRepositoryMock.Object);
            var expectedCollection = new List<City> { new City() { Id = 1, Name = "First", CountryId = 1}, new City() { Id = 2, Name = "I dont know", CountryId = 2}, new City() { Id = 44, Name = "Test", CountryId = 2} };

            Expression<Func<City, bool>> expectedFilter = x => x.Id == id;
            Expression<Func<City, string>> expectedSort = x => x.Name;


            Expression<Func<City, bool>> actual = null;
            cityRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<City, bool>>>())).Callback<Expression<Func<City, bool>>>(x => actual = x);

            // Act
            locationService.GetCityInCountry(id);

            var actualCollection = expectedCollection.Where(x => actual.Compile()(x));
            var myExpectCollection = expectedCollection.Where(x => expectedFilter.Compile()(x));
            //  myExpectCollection = myExpectCollection.OrderBy(x => expectedSort.Compile()(x));
             //myExpectCollection = myExpectCollection.OrderBy(x => x.Name);

            CollectionAssert.AreEquivalent(actualCollection, myExpectCollection);
            // Assert
          //  Assert.AreEqual(2, actualCollection.Count);
        }
    }
}

