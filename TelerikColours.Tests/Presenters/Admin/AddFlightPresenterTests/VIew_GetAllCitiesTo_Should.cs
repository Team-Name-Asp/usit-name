using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddFlight;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddFlightPresenterTests
{
    [TestFixture]
    public class VIew_GetAllCitiesTo_Should
    {
        [TestCase(22)]
        [TestCase(1)]
        public void SetCityTolistOnVIewModelWithExpectedCollection_WhenGetAllCitiesToEventIsRaised(int countryId)
        {
            // Arrange
            var viewStub = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceMock = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            var addFlightPresenter = new AddFlightPresenter(viewStub.Object, locationServiceStub.Object, factoryServiceMock.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object);

            var expectedCities = new List<City>()
            {
                new City("NoName", It.IsAny<int>()),
                new City("Name2", It.IsAny<int>()),
                new City("Name3", It.IsAny<int>())
            };

            var citiesCustomEventArgs = new CitiesCustomEventArgs(countryId);

            locationServiceStub.Setup(l => l.GetCityInCountry(countryId)).Returns(expectedCities);
            viewStub.Setup(v => v.Model).Returns(new FlightViewModel());

            // Act
            viewStub.Raise(v => v.GetAllCitiesTo += null, citiesCustomEventArgs);

            // Assert
            CollectionAssert.AreEquivalent(expectedCities, viewStub.Object.Model.CityToList);
        }
    }
}
