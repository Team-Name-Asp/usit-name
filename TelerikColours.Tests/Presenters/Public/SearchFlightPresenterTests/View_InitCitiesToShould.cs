using Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Public.SearchFlight;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.SearchFlightPresenterTests
{
    [TestFixture]
    public class View_InitCitiesToShould
    {
        [Test]
        public void SetCitieTo_OfViewModel_WithExpectedCollection()
        {
            // Arrange
            var viewMock = new Mock<ISearchFlightView>();
            var locationServiceStub = new Mock<ILocationService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServicStub = new Mock<IAirportService>();

            var presenter = new SearchFlightPresenter(viewMock.Object, flightServiceStub.Object, locationServiceStub.Object, airportServicStub.Object);
            viewMock.Setup(x => x.Model).Returns(new SearchFlightViewModel());
            var expectedCitiesCollection = new List<City>() { new City("CIty1", 22), new City("City2", 1) };
            locationServiceStub.Setup(x => x.GetCityInCountry(It.IsAny<int>())).Returns(expectedCitiesCollection);
            var cityEventArgs = new CitiesCustomEventArgs(It.IsAny<int>());

            // Act
            presenter.View_InitCitiesTo(It.IsAny<object>(), cityEventArgs);

            // Assert
            CollectionAssert.AreEqual(expectedCitiesCollection, viewMock.Object.Model.CitiesTo);
        }

        [TestCase(1)]
        [TestCase(99)]
        public void Call_GetCityInCountry_OnLocationService_WithProvidedParameters(int countryId)
        {
            // Arrange
            var viewStub = new Mock<ISearchFlightView>();
            var locationServiceMock = new Mock<ILocationService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServicStub = new Mock<IAirportService>();

            var presenter = new SearchFlightPresenter(viewStub.Object, flightServiceStub.Object, locationServiceMock.Object, airportServicStub.Object);
            viewStub.Setup(x => x.Model).Returns(new SearchFlightViewModel());
            var cityEventArgs = new CitiesCustomEventArgs(countryId);

            // Act
            presenter.View_InitCitiesTo(It.IsAny<object>(), cityEventArgs);

            // Assert
            locationServiceMock.Verify(x => x.GetCityInCountry(It.Is<int>(id => id == countryId)), Times.Once);
        }
    }
}
