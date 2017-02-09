using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.LocationServiceTests
{
    [TestFixture]
    public class ConstructorShoud
    {
        [Test]
        public void Throw_WithExpectedMessage_When_IRepositoryOfCountry_IsNull()
        {
            // Arrange
            var cityRepositoryStub = new Mock<IRepository<City>>().Object;
            string expectedContainingString = "CountryRepository";

            // Act and Assert
            var output = Assert.Throws<NullReferenceException>(() => new LocationService(null, cityRepositoryStub));

            StringAssert.Contains(expectedContainingString, output.Message);
        }

        [Test]
        public void Throw_WithExpectedMessage_When_IRepositoryOfCity_IsNull()
        {
            // Arrange
            var countryRepositoryStub = new Mock<IRepository<Country>>().Object;
            string expectedContainingString = "CityRepository";

            // Act and Assert
            var output = Assert.Throws<NullReferenceException>(() => new LocationService(countryRepositoryStub, null));

            StringAssert.Contains(expectedContainingString, output.Message);
        }
    }
}
