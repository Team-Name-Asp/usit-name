using System;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.CustomEventArgs;
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
            this.View.InitSubmit += View_InitSubmit;
            this.View.InitAirportDeparture += View_InitAirportDeparture;
            this.View.InitAirportArival += View_InitAirportArival;
            this.View.InitCitiesTo += View_InitCitiesTo;
        }

        public void View_InitCitiesTo(object sender, CitiesCustomEventArgs e)
        {
            this.View.Model.CitiesTo = this.locationService.GetCityInCountry(e.CountryId);
        }

        public void View_InitAirportArival(object sender, AirportsCustomEventArgs e)
        {
             this.View.Model.AirportArival = this.flightService.GetAllAirportsInCity(e.CityId);
        }

        public void View_InitAirportDeparture(object sender, AirportsCustomEventArgs e)
        {
            this.View.Model.AirportsDeparture = this.flightService.GetAllAirportsInCity(e.CityId);
        }

        public void View_InitSubmit(object sender, SearchFlightCustomEventArgs e)
        {
            var flights = this.flightService.GetFlights(e.DepartureAirportId, e.ArivalAirportId, e.DateOfDeparture, e.PassangersCount);

            this.View.Model.Flights = flights;
        }

        public void View_InitCitiesFrom(object sender,CitiesCustomEventArgs e)
        {
            this.View.Model.CitiesFrom = this.locationService.GetCityInCountry(e.CountryId);
        }

        public void View_InitCountries(object sender, EventArgs e)
        {
            var countries = this.locationService.GetAllCountries();

            this.View.Model.CountriesFrom = countries;
            this.View.Model.CountriesTo = countries;
        }
    }
}
