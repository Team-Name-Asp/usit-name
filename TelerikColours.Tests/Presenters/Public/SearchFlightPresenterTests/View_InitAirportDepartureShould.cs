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
    class View_InitAirportDepartureShould
    {
        [Test]
        public void SetAirportArival_OfViewModel_WithExpectedCollection()
        {
            // Arrange
            var viewMock = new Mock<ISearchFlightView>();
            var locationServiceStub = new Mock<ILocationService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServicMock = new Mock<IAirportService>();

            var presenter = new SearchFlightPresenter(viewMock.Object, flightServiceStub.Object, locationServiceStub.Object, airportServicMock.Object);
            viewMock.Setup(x => x.Model).Returns(new SearchFlightViewModel());
            var expectedAirportsCollection = new List<Airport>() { new Airport("Airport1", 2), new Airport("Airport2222", 11) };
            airportServicMock.Setup(x => x.GetAllAirportsInCity(It.IsAny<int>())).Returns(expectedAirportsCollection);
            var airportEventArgs = new AirportsCustomEventArgs(It.IsAny<int>());

            // Act
            presenter.View_InitAirportDeparture(It.IsAny<object>(), airportEventArgs);

            // Assert
            CollectionAssert.AreEqual(expectedAirportsCollection, viewMock.Object.Model.AirportsDeparture);
        }

        [TestCase(1)]
        [TestCase(99)]
        public void Call_GetCityInCountry_OnLocationService_WithProvidedParameters(int cityId)
        {
            // Arrange
            var viewStub = new Mock<ISearchFlightView>();
            var locationServiceMock = new Mock<ILocationService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServicMock = new Mock<IAirportService>();

            var presenter = new SearchFlightPresenter(viewStub.Object, flightServiceStub.Object, locationServiceMock.Object, airportServicMock.Object);
            viewStub.Setup(x => x.Model).Returns(new SearchFlightViewModel());
            var airportEventArgs = new AirportsCustomEventArgs(cityId);

            // Act
            presenter.View_InitAirportDeparture(It.IsAny<object>(), airportEventArgs);

            // Assert
            airportServicMock.Verify(x => x.GetAllAirportsInCity(It.Is<int>(id => id == cityId)), Times.Once);
        }
    }
}

