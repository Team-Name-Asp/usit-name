using System;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.FlightDetails
{
    public class FlightDetailsPresenter : Presenter<IFlightView>
    {
        private readonly IFlightService flightService;

        public FlightDetailsPresenter(IFlightView view, IFlightService flightService)
            : base(view)
        {
            if (flightService == null)
            {
                throw new NullReferenceException("IFlightService");
            }

            this.flightService = flightService;

            this.View.InitFlight += View_InitFlight;
        }

        private void View_InitFlight(object sender, DetailsFlightCustomEventArgs e)
        {
            this.View.Model.Flight = this.flightService.GetDetailedFlight(e.FlightId);
        }
    }
}

