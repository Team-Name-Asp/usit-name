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
    public class View_GetAllAirportsTo_Should
    {
        [TestCase(22)]
        [TestCase(1)]
        public void SetAllAirportsToListOnViewModelWithExpectedCollection_WhenGetAllAirportsToEventIsRaised(int cityId)
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
                new Airport("Name", cityId),
                new Airport("Name2", cityId),
                new Airport("Name3", 321)
            };

            airportServiceStub.Setup(a => a.GetAllAirportsInCity(cityId)).Returns(expectedAirports);

            var airportsCustomEventArgs = new AirportsCustomEventArgs(cityId);

            viewStub.Setup(v => v.Model).Returns(new FlightViewModel());

            // Act
            viewStub.Raise(v => v.GetAllAirportsTo += null, airportsCustomEventArgs);

            // Assert
            CollectionAssert.AreEquivalent(expectedAirports, viewStub.Object.Model.AirportToList);
        }
    }
}
