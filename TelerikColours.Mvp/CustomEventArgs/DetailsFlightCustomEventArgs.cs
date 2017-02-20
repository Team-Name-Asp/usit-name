using System;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class DetailsFlightCustomEventArgs: EventArgs
    {
        public DetailsFlightCustomEventArgs(int flightId)
        {
            this.FlightId = flightId;
        }
        public int FlightId { get; set; }
    }
}
