using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.AirportServiceTests
{
    [TestFixture]
    public class GetAllAirportsInCityShould
    {
        [TestCase(1)]
        [TestCase(33)]
        public void Get_AllAirportsInCity_WithExpectedExpressions(int id)
        {
            // Arrange
            var airportRepositoryMock = new Mock<IRepository<Airport>>();

            var airportService = new AirportService(airportRepositoryMock.Object);

            var expectedCollection = new List<Airport> { new Airport() { Id = 1, Name = "First", CityId = 1 }, new Airport() { Id = 2, Name = "I dont know", CityId = 33 }, new Airport() { Id = 61, Name = "ATest", CityId = 1 } };

            Expression<Func<Airport, bool>> expectedFilter = x => x.CityId == id;
            Expression<Func<Airport, string>> expectedSort = x => x.Name;

            Expression<Func<Airport, bool>> actual = null;
            Expression<Func<Airport, string>> sort = null;

            airportRepositoryMock.Setup(x => x.GetAll((It.IsAny<Expression<Func<Airport, bool>>>()), It.IsAny<Expression<Func<Airport, string>>>())).Callback<Expression<Func<Airport, bool>>, Expression<Func<Airport, string>>>((x, y) =>
            {
                actual = x;
                sort = y;
            });

            // Act
            airportService.GetAllAirportsInCity(id);

            var actualCollection = expectedCollection.Where(x => actual.Compile()(x));

            actualCollection = actualCollection.OrderBy(x => sort.Compile()(x));

            var myExpectCollection = expectedCollection
                .Where(x => expectedFilter.Compile()(x))
                .OrderBy(x => x.Name);

            // Assert
            CollectionAssert.AreEqual(actualCollection, myExpectCollection);
        }

        public void Return_ExpectedCollection()
        {
            // Arrange
            var airportRepositoryMock = new Mock<IRepository<Airport>>();

            var airportService = new AirportService(airportRepositoryMock.Object);

            var expectedCollection = new List<Airport> { new Airport() { Id = 1, Name = "First", CityId = 1 }, new Airport() { Id = 2, Name = "I dont know", CityId = 33 }, new Airport() { Id = 61, Name = "ATest", CityId = 1 } };

            airportRepositoryMock.Setup(x => x.GetAll((It.IsAny<Expression<Func<Airport, bool>>>()), It.IsAny<Expression<Func<Airport, string>>>())).Returns(expectedCollection);

            // Act
            var actualCollection = airportService.GetAllAirportsInCity(It.IsAny<int>());

            // Assert
            CollectionAssert.AreEqual(actualCollection, expectedCollection);
        }
    }
}
