using System;
using TelerikColours.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.SearchFlight
{
    public class SearchFlightPresenter : Presenter<ISearchFlightView>
    {
        private readonly IFlightService flightService;
        private readonly ILocationService locationService;
        public SearchFlightPresenter(ISearchFlightView view, IFlightService flightService, ILocationService locationService)
            : base(view)
        {
            if(flightService == null)
            {
                throw new NullReferenceException("IFlightService");
            }

            if (locationService == null)
            {
                throw new NullReferenceException("ILocationService");
            }

            this.flightService = flightService;
            this.locationService = locationService;

            this.View.InitCountries += View_InitCountries;
            this.View.InitCitiesFrom += View_InitCitiesFrom;
            this.View.InitCitiesTo += View_InitCountriesTo;
        }

        private void View_InitCountriesTo(object sender, CitiesCustomEventArgs e)
        {
            this.View.Model.CitiesTo = this.locationService.GetCityInCountry(e.CountryId);
        }

        private void View_InitCitiesFrom(object sender,CitiesCustomEventArgs e)
        {
            this.View.Model.CitiesFrom = this.locationService.GetCityInCountry(e.CountryId);
        }

        private void View_InitCountries(object sender, EventArgs e)
        {
            this.View.Model.CountriesFrom = this.locationService.GetAllCountries();
        }
    }
}
