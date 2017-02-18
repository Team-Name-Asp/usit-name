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
    public class View_CreateFlight_Should
    {
        [TestCase(2, 32, 123, 1, 3)]
        [TestCase(23, 312, 4123, 11, 2)]
        public void CallAddFlightOnFactoryServiceWithExpectedParameters_WhenCreateFlightEventIsCalled(int departureAirportId, int arrivalAirportId, decimal price, int airlineId, int availableSeats)
        {
            // Arrange
            var viewStub = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceMock = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            var addFlightPresenter = new AddFlightPresenter(viewStub.Object, locationServiceStub.Object, factoryServiceMock.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object);
            var departureDate = new DateTime(1999, 10, 10);
            var arivalDate = new DateTime(1999, 10, 11);


            var createFlightCustomEventArgs = new CreateFlightCustomEventArgs(departureAirportId, arrivalAirportId, price, departureDate, arivalDate,  airlineId, availableSeats);

            // Act
            viewStub.Raise(v => v.CreateFlight += null, createFlightCustomEventArgs);

            // Assert
            factoryServiceMock.Verify(f => f.AddFlight(
                It.Is<int>(aAId => aAId == arrivalAirportId),
                 It.Is<int>(aDId => aDId == departureAirportId),
                 It.Is<DateTime>(dDate => dDate == departureDate),
                 It.Is<DateTime>(aDate => aDate == arivalDate),
                 It.Is<decimal>(p => p == price),
                  It.Is<int>(airlId => airlId == airlineId),
                   It.Is<int>(seats => seats == availableSeats)), Times.Once);
        }
    }
}
