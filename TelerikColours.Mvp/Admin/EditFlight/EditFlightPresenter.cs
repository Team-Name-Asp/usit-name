using Models;
using System;
using System.Web.ModelBinding;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.EditFlight
{
    public class EditFlightPresenter: Presenter<IEditFlightView>
    {
        private IFlightService flightService;
        public EditFlightPresenter(IEditFlightView view, IFlightService flightService)
            : base(view)
        {
            if (flightService == null)
            {
                throw new NullReferenceException("IFlightService");
            }

            this.flightService = flightService;

            this.View.InitFlights += this.View_InitFlights;
            this.View.UpdateFlight += this.View_UpdateFlight;
        }

        private void View_UpdateFlight(object sender, FlightEditCustomEventArgs e)
        {
            Flight item = this.flightService.GetFlightForUpdate(e.FlightId);

            if (item == null)
            {
                // The item wasn't found
                this.View.ModelState.AddModelError("", String.Format("Item with id {0} was not found", e.FlightId));
                return;
            }
            this.View.TryUpdateModel(item);

            if (this.View.ModelState.IsValid)
            {
                this.flightService.SaveUpdatedFlight();
            }
        }

        private void View_InitFlights(object sender, FlightFilterCustomEventArgs e)
        {
            this.View.Model.Flights = this.flightService.FilterFlights(e.SortType, e.SortExpression);
        }
    }
}
