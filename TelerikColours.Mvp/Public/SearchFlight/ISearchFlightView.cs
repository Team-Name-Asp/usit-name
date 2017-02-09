using System;
using TelerikColours.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.SearchFlight
{
    public interface ISearchFlightView : IView<SearchFlightViewModel>
    {
        event EventHandler InitCountries;
        event EventHandler<CitiesCustomEventArgs> InitCitiesFrom;
        event EventHandler<CitiesCustomEventArgs> InitCitiesTo;
    }
}
