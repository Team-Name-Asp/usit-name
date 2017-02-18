using System;
using TelerikColours.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddFlight
{
    public interface ICreateFlightVliew : IView<FlightViewModel>
    {
        event EventHandler InitialLoad;

        event EventHandler<CitiesCustomEventArgs> GetAllCitiesFrom;

        event EventHandler<AirportsCustomEventArgs> GetAllAirportsFrom;

        event EventHandler<CitiesCustomEventArgs> GetAllCitiesTo;

        event EventHandler<AirportsCustomEventArgs> GetAllAirportsTo;

        event EventHandler<CreateFlightCustomEventArgs> CreateFlight;
    }
}
