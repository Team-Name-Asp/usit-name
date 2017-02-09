using System;

namespace TelerikColours.CustomEventArgs
{
    public class CreateFlightCustomEventArgs: EventArgs
    {
        public int DepartureAirportId { get; set; }

        public int ArrivalAirportId { get; set; }

        public decimal Price { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int AirlineId { get; set; }

        public CreateFlightCustomEventArgs(int departureAirportId, int arrivalAirportId, decimal price, DateTime departureDate, DateTime arrivalDate, int airlineId)
        {
            this.DepartureAirportId = departureAirportId;
            this.ArrivalAirportId = arrivalAirportId;
            this.Price = price;
            this.DepartureDate = departureDate;
            this.ArrivalDate = arrivalDate;
            this.AirlineId = airlineId;
        }
    }
}
