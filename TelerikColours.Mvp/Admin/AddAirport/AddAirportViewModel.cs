using Models;
using System.Collections.Generic;

namespace TelerikColours.Mvp.Admin.AddAirport
{
    public class AddAirportViewModel
    {
        public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
