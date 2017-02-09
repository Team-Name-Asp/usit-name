using Models;
using System.Collections.Generic;

namespace TelerikColours.Mvp.Admin.AddJob
{
    public class AddJobViewModel
    {
        public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
