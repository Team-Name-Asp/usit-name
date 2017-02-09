using System;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddAirport
{
    public interface IAddAirportView: IView<AddAirportViewModel>
    {
        event EventHandler InitCountries;

        event EventHandler<CitiesCustomEventArgs> InitCities;

        event EventHandler<AddAirportCustomEventArgs> SubmitAddAirport;
    }
}
