using Models;
using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Admin.EditFlight;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.EditFlightPresenterTests
{
    [TestFixture]
    public class VIewUpdateFlightShould
    {
        [Test]
        public void SetUpdateFlight_WithExpectedValue()
        {
            // Arrange
            var viewStub = new Mock<IEditFlightView>();
            var serviceMock = new Mock<IFlightService>();
            var editFlightPresenter = new EditFlightPresenter(viewStub.Object, serviceMock.Object);
            viewStub.Setup(x => x.Model).Returns(new EditFlightViewModel());

            var expectedFlight = new Flight();
            serviceMock.Setup(x => x.GetFlightForUpdate(It.IsAny<int>())).Returns(expectedFlight);

            var flightEditEventArgs = new FlightEditCustomEventArgs(It.IsAny<int>());
         
            // Act
            editFlightPresenter.View_UpdateFlight(It.IsAny<object>(), flightEditEventArgs);

            // Assert
            Assert.AreSame(expectedFlight, viewStub.Object.Model.UpdatedFlight);
        }

        [TestCase(10)]
        [TestCase(1)]
        public void CallGetFlightsForUpdate_OnFlightService_WithExpectedArgument(int id)
        {
            // Arrange
            var viewStub = new Mock<IEditFlightView>();
            var serviceMock = new Mock<IFlightService>();
            var editFlightPresenter = new EditFlightPresenter(viewStub.Object, serviceMock.Object);
            viewStub.Setup(x => x.Model).Returns(new EditFlightViewModel());
            var flightEditEventArgs = new FlightEditCustomEventArgs(id);

            // Act
            editFlightPresenter.View_UpdateFlight(It.IsAny<object>(), flightEditEventArgs);

            // Assert
            serviceMock.Verify(x => x.GetFlightForUpdate(It.Is<int>(arg => arg == id)), Times.Once);
        }
    }
}

