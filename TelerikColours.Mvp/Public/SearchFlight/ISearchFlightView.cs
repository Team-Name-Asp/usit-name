using System;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.SearchFlight
{
    public interface ISearchFlightView : IView<SearchFlightViewModel>
    {
        event EventHandler InitCountries;
        event EventHandler<CitiesCustomEventArgs> InitCitiesFrom;
        event EventHandler<CitiesCustomEventArgs> InitCitiesTo;
        event EventHandler<SearchFlightCustomEventArgs> InitSubmit;
        event EventHandler<AirportsCustomEventArgs> InitAirportDeparture;
        event EventHandler<AirportsCustomEventArgs> InitAirportArival;
    }
}
