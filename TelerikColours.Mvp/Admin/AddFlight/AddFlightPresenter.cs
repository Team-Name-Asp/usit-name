using System;
using TelerikColours.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddFlight
{
    public class AddFlightPresenter : Presenter<ICreateFlightVliew>
    {
        private readonly ILocationService locationService;
        private readonly IFactoryService factoryService;
        private readonly IFlightService flightService;
        private readonly IAirportService airportService;
        private readonly IAirlineService airlineService;

        public AddFlightPresenter(ICreateFlightVliew view, ILocationService locatonService, IFactoryService factoryService, IFlightService flightService, IAirportService airportService, IAirlineService airlineService)
            :base(view)
        {
            if(locatonService == null)
            {
                throw new NullReferenceException("ILocationService");
            }

            if(factoryService == null)
            {
                throw new NullReferenceException("IFactoryService");
            }

            if (flightService == null)
            {
                throw new NullReferenceException("IFlightService");

            }

            if(airportService == null)
            {
                throw new NullReferenceException("IAirportService");
            }

            if(airlineService == null)
            {
                throw new NullReferenceException("IAirlineService");
            }

            this.locationService = locatonService;
            this.factoryService = factoryService;
            this.flightService = flightService;
            this.airportService = airportService;
            this.airlineService = airlineService;

            this.View.InitialLoad += View_InitialLoad;
            this.View.GetAllCitiesFrom += View_GetAllCitiesFrom;
            this.View.GetAllCitiesTo += View_GetAllCitiesTo;
            this.View.GetAllAirportsFrom += View_GetAllAirportsFrom;
            this.View.GetAllAirportsTo += View_GetAllAirportsTo;
            this.View.CreateFlight += View_CreateFlight;
        }

        private void View_CreateFlight(object sender, CreateFlightCustomEventArgs e)
        {
            this.factoryService.AddFlight(e.ArrivalAirportId, e.DepartureAirportId, e.DepartureDate, e.ArrivalDate, e.Price, e.AirlineId, e.AvailableSeats);
        }

        private void View_GetAllAirportsTo(object sender, AirportsCustomEventArgs e)
        {
            var airports = this.airportService.GetAllAirportsInCity(e.CityId);

            this.View.Model.AirportToList = airports;
        }

        private void View_GetAllAirportsFrom(object sender, AirportsCustomEventArgs e)
        {
            var airports = this.airportService.GetAllAirportsInCity(e.CityId);

            this.View.Model.AirportFromList = airports;
        }

        private void View_GetAllCitiesTo(object sender, CitiesCustomEventArgs e)
        {
            var cities = this.locationService.GetCityInCountry(e.CountryId);

            this.View.Model.CityToList = cities;
        }

        private void View_GetAllCitiesFrom(object sender, CitiesCustomEventArgs e)
        {
            var cities = this.locationService.GetCityInCountry(e.CountryId);

            this.View.Model.CityFromList = cities;
        }

        private void View_InitialLoad(object sender, EventArgs e)
        {
            var countries = this.locationService.GetAllCountries();
            var airlines = this.airlineService.GetAllAirlines();

            this.View.Model.CountryFromList = countries;
            this.View.Model.CountryToList = countries;
            this.View.Model.AirlineList = airlines;
        }
    }
}
