using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.SearchFlight;
using TelerikColours.Services.Contracts;
using TelerikColours.Services.Models;

namespace TelerikColours.Tests.Presenters.SearchFlightPresenterTests
{
    [TestFixture]
    public class View_InitSubmitShould
    {
        [Test]
        public void Set_Flights_OnViewModel_WithExpectedCollection()
        {
            // Arrange
            var viewMock = new Mock<ISearchFlightView>();
            var locationServiceStub = new Mock<ILocationService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServicStub = new Mock<IAirportService>();

            var presenter = new SearchFlightPresenter(viewMock.Object, flightServiceStub.Object, locationServiceStub.Object, airportServicStub.Object);

            viewMock.Setup(x => x.Model).Returns(new SearchFlightViewModel());

            var expectedFlightCollection = new List<PresentationFlight>() { new PresentationFlight(10, "cityDepartureName", "cityArivalName", "airportDepartureName", "airportArivalName", new DateTime(2017, 10, 10), new DateTime(2017, 10, 11), 22, "airlineName"), new PresentationFlight(120, "cityDepartureName1", "cityArivalaName", "airportDepartureName1", "airportArivalName", new DateTime(2017, 11, 10), new DateTime(2017, 11, 11), 22, "airlineNamse"), };

                flightServiceStub.Setup(x => x.GetFlights(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<int>())).Returns(expectedFlightCollection);

            var customEventArgs = new SearchFlightCustomEventArgs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<int>());

            // Act
            presenter.View_InitSubmit(It.IsAny<object>(), customEventArgs);

            // Assert
            CollectionAssert.AreEqual(expectedFlightCollection, viewMock.Object.Model.Flights);
        }

        [TestCase(1, 2, 2016, 10, 10, 20)]
        [TestCase(1, 22, 2015, 10, 11, 202)]
        public void Call_GetFlights_WithExpectedParameters(int departureAirportId, int arivalAirportId, int year, int month, int day, int passangerCount)
        {
            // Arrange
            var viewStub = new Mock<ISearchFlightView>();
            var locationServiceStub = new Mock<ILocationService>();
            var flightServiceMock = new Mock<IFlightService>();
            var airportServicStub = new Mock<IAirportService>();

            var presenter = new SearchFlightPresenter(viewStub.Object, flightServiceMock.Object, locationServiceStub.Object, airportServicStub.Object);

            viewStub.Setup(x => x.Model).Returns(new SearchFlightViewModel());

            var customEventArgs = new SearchFlightCustomEventArgs(departureAirportId, arivalAirportId,new DateTime(year, month, day), passangerCount);

            // Act
            presenter.View_InitSubmit(It.IsAny<object>(), customEventArgs);

            // Assert
            flightServiceMock.Verify(x => x.GetFlights(It.Is<int>(departAirportId => departAirportId == departureAirportId), It.Is<int>(arivAIrportId => arivAIrportId == arivalAirportId), It.Is<DateTime>(d => d.Day == day && d.Year == year && d.Month == month), It.Is<int>(count => count == passangerCount)), Times.Once);
        }
    }
}
