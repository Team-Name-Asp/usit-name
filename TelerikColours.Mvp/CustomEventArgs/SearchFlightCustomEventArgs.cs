using System;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class SearchFlightCustomEventArgs : EventArgs
    {
        public SearchFlightCustomEventArgs(int departureAirportId, int arrivalAirportId, DateTime dateOfDeparture, int passangersCount)
        {
            this.DepartureAirportId = departureAirportId;
            this.ArivalAirportId = arrivalAirportId;
            this.DateOfDeparture = dateOfDeparture;
            this.PassangersCount = passangersCount;
        }

        public int DepartureAirportId { get; set; }

        public int ArivalAirportId { get; set; }

        public DateTime DateOfDeparture { get; set; }

        public int PassangersCount { get; set; }
    }
}
