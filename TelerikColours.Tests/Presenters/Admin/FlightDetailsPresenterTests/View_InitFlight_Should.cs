using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.Admin.FlightDetails;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.FlightDetailsPresenterTests
{
    [TestFixture]
    public class View_InitFlight_Should
    {
        [TestCase(22)]
        [TestCase(1)]

        public void SetFlightOnViewModelWithExpectedCollection_WhenIntFlightEventIsRaised(int flightId)
        {
            // Arrange
            var flightViewMock = new Mock<IFlightView>();
            var flightServiceStub = new Mock<IFlightService>();
            var flightDetailPresenter = new FlightDetailsPresenter(flightViewMock.Object, flightServiceStub.Object);

            flightViewMock.Setup(v => v.Model).Returns(new FlightDetailsViewModel());

            var eventArgs = new DetailsFlightCustomEventArgs(flightId);
            var expectedFlight = new Flight();

            flightServiceStub.Setup(f => f.GetDetailedFlight(flightId)).Returns(expectedFlight);
            // Act
            flightViewMock.Raise(v => v.InitFlight += null, eventArgs);

            // Assert
            Assert.AreEqual(expectedFlight, flightViewMock.Object.Model.Flight);
        }
    }
}
