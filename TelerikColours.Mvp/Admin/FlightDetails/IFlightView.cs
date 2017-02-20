using System;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.FlightDetails
{
    public interface IFlightView: IView<FlightDetailsViewModel>
    {
        event EventHandler<DetailsFlightCustomEventArgs> InitFlight;
    }
}
