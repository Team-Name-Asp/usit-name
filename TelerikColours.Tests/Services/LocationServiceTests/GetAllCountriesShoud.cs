using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.LocationServiceTests
{
    [TestFixture]
    public class GetAllCountriesShoud
    {
        [Test]
        public void ReturnExpectedCollectionOfCountries()
        {
            // Arrange
            var countryRepositoryMock = new Mock<IRepository<Country>>();
            var cityRepositoryStub = new Mock<IRepository<City>>().Object;
            var locationService = new LocationService(countryRepositoryMock.Object, cityRepositoryStub);
            var expectedCollection = new List<Country> { new Country() { Id = 1, Name = "First" }, new Country() { Id = 2, Name = "I dont know" } };
            countryRepositoryMock.Setup(x => x.GetAll()).Returns(expectedCollection);

            // Act
            var actualCollection = locationService.GetAllCountries();

            // Assert
            Assert.AreEqual(expectedCollection, actualCollection);
        }
    }
}
