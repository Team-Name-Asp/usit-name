using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Admin.EditFlight;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.EditFlightPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReference_WithMessageContaining_IFlightService_WhenIFlightServiceIsNull()
        {
            // Arrange
            var stubbedView = new Mock<IEditFlightView>();
            var expected = "IFlightService";

            // Act and Assert
            var exception = Assert.Throws<NullReferenceException>(() => new EditFlightPresenter(stubbedView.Object, null));

            StringAssert.Contains(expected, exception.Message);
        }

}
}

//private IFlightService flightService;
//public EditFlightPresenter(IEditFlightView view, IFlightService flightService)
//            : base(view)
//        {
//    if (flightService == null)
//    {
//        throw new NullReferenceException("IFlightService");
//    }

//    this.flightService = flightService;
//    this.View.InitFlights += View_InitFlights;
//    this.View.UpdateFlight += View_UpdateFlight;
//    this.View.CommitChanges += View_CommitChanges;
//}

//private void View_CommitChanges(object sender, EventArgs e)
//{
//    this.flightService.SaveUpdatedFlight();
//}

//private void View_UpdateFlight(object sender, CustomEventArgs.FlightEditCustomEventArgs e)
//{
//    this.View.Model.UpdatedFlight = this.flightService.GetFlightForUpdate(e.FlightId);
//}

//private void View_InitFlights(object sender, CustomEventArgs.FlightSortCustomEventArgs e)
//{
//    this.View.Model.Flights = this.flightService.FilterFlights(e.SortType, e.SortExpression);
//}
//    }
//}


//var wasCalled = false;
//foo.NyEvent += (o,e) => wasCalled = true;

//...

//Assert.IsTrue(wasCalled);