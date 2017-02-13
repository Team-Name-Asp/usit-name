using System;

namespace Models
{
    public class Flight
    {

        public Flight()
        {
        }

        public Flight(int airlineId, int airportArrivalId, int airportDepartureId, DateTime arrivalDate, DateTime departureDate, decimal price, int availableSeats)
            : base()
        {
            this.AirlineId = airlineId;
            this.AirportArrivalId = airportArrivalId;
            this.AirportDepartureId = airportDepartureId;
            this.DateOfArrival = arrivalDate;
            this.DateOfDeparture = departureDate;
            this.AvailableSeats = availableSeats;
            this.Price = price;

        }
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int AvailableSeats { get; set; }

        public DateTime DateOfDeparture { get; set; }

        public DateTime DateOfArrival { get; set; }

        public int AirlineId { get; set; }

        public virtual Airline Airline { get; set; }

        public int AirportDepartureId { get; set; }

        public virtual Airport AirportDeparture { get; set; }

        public int AirportArrivalId { get; set; }

        public virtual Airport AirportArrival { get; set; }
    }
}
