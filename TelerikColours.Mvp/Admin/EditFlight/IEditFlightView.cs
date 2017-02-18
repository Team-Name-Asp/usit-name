using System;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.EditFlight
{
    public interface IEditFlightView: IView<EditFlightViewModel>
    {
        event EventHandler<FlightFilterCustomEventArgs> InitFlights;
        event EventHandler<FlightEditCustomEventArgs> UpdateFlight;
        event EventHandler CommitChanges;
    }
}
