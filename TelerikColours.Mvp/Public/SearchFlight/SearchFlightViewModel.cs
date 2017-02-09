using Models;
using System.Collections.Generic;

namespace TelerikColours.Mvp.Public.SearchFlight
{
    public class SearchFlightViewModel
    {
        public IEnumerable<Country> CountriesFrom { get; set; }

        public IEnumerable<City> CitiesFrom { get; set; }

        public IEnumerable<Country> CountryTo { get; set; }

        public IEnumerable<City> CitiesTo { get; set; }
    }
}
