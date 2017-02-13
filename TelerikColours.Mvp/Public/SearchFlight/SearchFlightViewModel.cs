using Models;
using System.Collections.Generic;
using TelerikColours.Services.Models;

namespace TelerikColours.Mvp.Public.SearchFlight
{
    public class SearchFlightViewModel
    {
        public IEnumerable<Country> CountriesFrom { get; set; }

        public IEnumerable<City> CitiesFrom { get; set; }

        public IEnumerable<Country> CountriesTo { get; set; }

        public IEnumerable<City> CitiesTo { get; set; }

        public IEnumerable<Airport> AirportsDeparture { get; set; }

        public IEnumerable<Airport> AirportArival { get; set; }

        public IEnumerable<PresentationFlight> Flights { get; set; }
    }
}
