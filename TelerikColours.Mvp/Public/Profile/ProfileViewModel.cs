using Models;
using System.Collections.Generic;

namespace TelerikColours.Mvp.Public.Profile
{
    public class ProfileViewModel
    {
        public IEnumerable<Flight> FlightHistory { get; set; }

        public IEnumerable<Flight> UpcommingFlights { get; set; }

        public IEnumerable<Job> JobsHistory { get; set; }

        public IEnumerable<Job> UpcommingJobs { get; set; }
    }
}
