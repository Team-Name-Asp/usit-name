using Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddAirport;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddAirportPresenterTests
{
    [TestFixture]
    public class View_InitCities_Should
    {
        [TestCase(222)]
        [TestCase(22)]
        public void AddCitiesToViewModel_WhenInitCitiesEventIsRaised(int countryId)
        {
            // Arrange
            var locationServiceMock = new Mock<ILocationService>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var viewMock = new Mock<IAddAirportView>();

            var citiesCustomEventArgs = new CitiesCustomEventArgs(countryId);

            var addAirportPresenter = new AddAirportPresenter(viewMock.Object, locationServiceMock.Object, factoryServiceStub.Object);
            viewMock.Setup(v => v.Model).Returns(new AddAirportViewModel());

            var cities = new List<City>()
            {
                new City("Name", countryId),
                new City("Name2", countryId)
            };

            locationServiceMock.Setup(l => l.GetCityInCountry(countryId)).Returns(cities);

            // Act
            viewMock.Raise(v => v.InitCities += null, citiesCustomEventArgs);

            // Assert
            CollectionAssert.AreEquivalent(cities, viewMock.Object.Model.Cities);
        }
    }
}
