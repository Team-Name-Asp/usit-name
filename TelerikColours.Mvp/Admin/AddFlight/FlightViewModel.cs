using Models;
using System.Collections.Generic;

namespace TelerikColours.Mvp.Admin.AddFlight
{
    public class FlightViewModel
    {
        public IEnumerable<Country> CountryFromList;

        public IEnumerable<City> CityFromList;

        public IEnumerable<Airport> AirportFromList;

        public IEnumerable<Country> CountryToList;

        public IEnumerable<City> CityToList;

        public IEnumerable<Airport> AirportToList;

        public IEnumerable<Airline> AirlineList;
    }
}
