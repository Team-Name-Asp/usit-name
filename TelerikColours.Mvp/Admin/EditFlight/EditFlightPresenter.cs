using System;
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
            this.View.InitFlights += View_InitFlights;
            this.View.UpdateFlight += View_UpdateFlight;
            this.View.CommitChanges += View_CommitChanges;
        }

        public void View_CommitChanges(object sender, EventArgs e)
        {
            this.flightService.SaveUpdatedFlight();
        }

        public void View_UpdateFlight(object sender, FlightEditCustomEventArgs e)
        {
            this.View.Model.UpdatedFlight = this.flightService.GetFlightForUpdate(e.FlightId);
        }

        public void View_InitFlights(object sender, FlightFilterCustomEventArgs e)
        {
            this.View.Model.Flights = this.flightService.FilterFlights(e.SortType, e.SortExpression);
        }
    }
}
