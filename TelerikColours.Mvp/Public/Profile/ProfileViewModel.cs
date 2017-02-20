using Models;
using System.Collections.Generic;
using System.Linq;

namespace TelerikColours.Mvp.Public.Profile
{
    public class ProfileViewModel
    {
        public IEnumerable<Flight> FlightHistory { get; set; }

        public IEnumerable<Flight> UpcommingFlights { get; set; }
    }
}
