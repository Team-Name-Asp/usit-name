﻿using System;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int AvailableSeats { get; set; }

        [Required]
        public DateTime DateOfDeparture { get; set; }

        [Required]
        public DateTime DateOfArrival { get; set; }

        [Required]
        public int AirlineId { get; set; }

        [Required]
        public virtual Airline Airline { get; set; }

        [Required]
        public int AirportDepartureId { get; set; }

        public virtual Airport AirportDeparture { get; set; }

        [Required]
        public int AirportArrivalId { get; set; }

        public virtual Airport AirportArrival { get; set; }
    }
}
