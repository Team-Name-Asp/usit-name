using Models;
using System.Collections.Generic;
using System.Linq;

namespace TelerikColours.Mvp.Admin.EditFlight
{
    public class EditFlightViewModel
    {
        public IEnumerable<Flight> Flights { get; set; }

        public Flight UpdatedFlight { get; set; }
    }
}
