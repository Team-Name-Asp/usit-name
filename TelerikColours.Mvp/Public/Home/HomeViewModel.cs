using Models;
using System.Collections.Generic;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Flight> CheapestFlights { get; set; }
    }
}
