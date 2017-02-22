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
    }
}

//private void View_UpdateFlight(object sender, FlightEditCustomEventArgs e)
//{
//    Flight item = this.flightService.GetFlightForUpdate(e.FlightId);

//    if (item == null)
//    {
//        // The item wasn't found
//        this.View.ModelState.AddModelError("", String.Format("Item with id {0} was not found", e.FlightId));
//        return;
//    }
//    this.View.TryUpdateModel(item);

//    if (this.View.ModelState.IsValid)
//    {
//        this.flightService.SaveUpdatedFlight();
//    }
//}