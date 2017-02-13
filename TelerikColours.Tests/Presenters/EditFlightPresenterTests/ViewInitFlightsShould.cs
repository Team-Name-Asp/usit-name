using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.Admin.EditFlight;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.EditFlightPresenterTests
{
    [TestFixture]
    public class ViewInitFlightsShould
    {
        [Test]
        public void SetFlights_OnModel_OfView_WithExpectedCollection()
        {
            // Arrange
            var viewStub = new Mock<IEditFlightView>();
            var serviceMock = new Mock<IFlightService>();
            var editFlightPresenter = new EditFlightPresenter(viewStub.Object, serviceMock.Object);
            viewStub.Setup(x => x.Model).Returns(new EditFlightViewModel());

            var expectedFlightCollection = new List<Flight> { new Flight(), new Flight() };

            serviceMock.Setup(x => x.FilterFlights(It.IsAny<string>(), It.IsAny<string>())).Returns(expectedFlightCollection);

            var flightEditEventArgs = new FlightSortCustomEventArgs(It.IsAny<string>(), It.IsAny<string>());

            // Act
            editFlightPresenter.View_InitFlights(It.IsAny<object>(), flightEditEventArgs);

            // Assert
            Assert.AreSame(expectedFlightCollection, viewStub.Object.Model.Flights);
        }

        [TestCase("first", "second")]
        [TestCase("third", "fourth")]
        public void Call_FilterFlights_OnFlightService_WithExpectedArguments(string sortType, string sortExpression)
        {
            var viewStub = new Mock<IEditFlightView>();
            var serviceMock = new Mock<IFlightService>();
            var editFlightPresenter = new EditFlightPresenter(viewStub.Object, serviceMock.Object);
            viewStub.Setup(x => x.Model).Returns(new EditFlightViewModel());
            var flightSortEventArgs = new FlightSortCustomEventArgs(sortType, sortExpression);

            // Act
            editFlightPresenter.View_InitFlights(It.IsAny<object>(), flightSortEventArgs);

            // Assert
            serviceMock.Verify(x => x.FilterFlights(It.Is<string>(sType => sType == sortType), It.Is<string>(sExpression => sExpression == sortExpression)), Times.Once);
        }
    }
}
