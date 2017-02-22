using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Web.ModelBinding;
using TelerikColours.Mvp.Admin.EditFlight;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.FlightDetailsPresenterTests
{
    [TestFixture]
    public class View_UpdateFlight_Should
    {
        [TestCase(21)]
        [TestCase(11)]
        public void AddModelError_WhenItemIsNotFound(int id)
        {
            // Arrange
            var viewMock = new Mock<IEditFlightView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            var serviceMock = new Mock<IFlightService>();

            string expectedError = string.Format("Item with id {0} was not found", id);

            viewMock.Setup(x => x.Model).Returns(new EditFlightViewModel());
            serviceMock.Setup(s => s.GetFlightForUpdate(id)).Returns<Flight>(null);

            var editFlightPresenter = new EditFlightPresenter(viewMock.Object, serviceMock.Object);

            var customArgs = new FlightEditCustomEventArgs(id);

            // Act
            viewMock.Raise(v => v.UpdateFlight += null, customArgs);

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[string.Empty].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[String.Empty].Errors[0].ErrorMessage);
        }

        [TestCase(21)]
        [TestCase(11)]
        public void TryUpdateModelIsNotCalled_WhenItemIsNotFound(int id)
        {
            // Arrange
            var viewMock = new Mock<IEditFlightView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            var flightService = new Mock<IFlightService>();
            flightService.Setup(c => c.GetFlightForUpdate(id)).Returns<Flight>(null);

            var customArgs = new FlightEditCustomEventArgs(id);

            var presenter = new EditFlightPresenter
                (viewMock.Object, flightService.Object);

            // Act
            viewMock.Raise(v => v.UpdateFlight += null, customArgs);

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Flight>()), Times.Never());
        }


        [TestCase(21)]
        [TestCase(11)]
        public void TryUpdateModelIsCalled_WhenItemIsFound(int id)
        {
            // Arrange
            var viewMock = new Mock<IEditFlightView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            var flightServiceMock = new Mock<IFlightService>();
            flightServiceMock.Setup(c => c.GetFlightForUpdate(id)).Returns(new Flight() { Id = id });

            var editFlightPresenter = new EditFlightPresenter
                (viewMock.Object, flightServiceMock.Object);

            var customArgs = new FlightEditCustomEventArgs(id);

            // Act
            viewMock.Raise(v => v.UpdateFlight += null, customArgs);

            // Assert
            viewMock.Verify(v => v.TryUpdateModel(It.IsAny<Flight>()), Times.Once());
        }

        [TestCase(21)]
        [TestCase(11)]
        public void UpdateCategoryIsCalled_WhenItemIsFoundAndIsInValidState(int id)
        {
            // Arrange
            var viewMock = new Mock<IEditFlightView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            var flightServiceMock = new Mock<IFlightService>();
            var flight = new Flight() { Id = id };
            flightServiceMock.Setup(c => c.GetFlightForUpdate(id)).Returns(flight);

            var editFlightPresenter = new EditFlightPresenter
                (viewMock.Object, flightServiceMock.Object);

            var customArgs = new FlightEditCustomEventArgs(id);

            // Act
            viewMock.Raise(v => v.UpdateFlight += null, customArgs);

            // Assert
            flightServiceMock.Verify(c => c.GetFlightForUpdate(id), Times.Once());
        }

        [TestCase(21)]
        [TestCase(11)]
        public void UpdateCategoryIsNotCalled_WhenItemIsFoundAndIsInInvalidState(int id)
        {
            // Arrange
            var viewMock = new Mock<IEditFlightView>();
            var modelState = new ModelStateDictionary();

            modelState.AddModelError("test key", "test message");
            viewMock.Setup(v => v.ModelState).Returns(modelState);

            var flightServiceMock = new Mock<IFlightService>();

            var category = new Flight() { Id = id };
            flightServiceMock.Setup(c => c.GetFlightForUpdate(id)).Returns(category);

            var editFlightPresenter = new EditFlightPresenter
                (viewMock.Object, flightServiceMock.Object);

            var customArgs = new FlightEditCustomEventArgs(id);

            // Act
            viewMock.Raise(v => v.UpdateFlight += null, customArgs);

            // Assert
            flightServiceMock.Verify(c => c.SaveUpdatedFlight(), Times.Never());
        }
    }
}
