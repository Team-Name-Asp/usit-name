using Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddFlight;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddFlightPresenterTests
{
    [TestFixture]
    public class View_GetAllAirpotsFrom_Should
    {
        [TestCase(232)]
        [TestCase(1)]
        public void SetAllAirportsFromListOnViewModelWithExpectedCollection_WhenGetAllAirportsFromEventIsRaised(int cityId)
        {
            // Arrange
            var viewStub = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceMock = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            var addFlightPresenter = new AddFlightPresenter(viewStub.Object, locationServiceStub.Object, factoryServiceMock.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object);

            var expectedAirports = new List<Airport>()
            {
                new Airport("NoName", It.IsAny<int>()),
                new Airport("Name2", It.IsAny<int>()),
                new Airport("Name3", It.IsAny<int>())
            };

            airportServiceStub.Setup(a => a.GetAllAirportsInCity(cityId)).Returns(expectedAirports);

            var airportsCustomEventArgs = new AirportsCustomEventArgs(cityId);

            viewStub.Setup(v => v.Model).Returns(new FlightViewModel());

            // Act
            viewStub.Raise(v => v.GetAllAirportsFrom += null, airportsCustomEventArgs);

            // Assert
            CollectionAssert.AreEquivalent(expectedAirports, viewStub.Object.Model.AirportFromList);
        }
    }
}
