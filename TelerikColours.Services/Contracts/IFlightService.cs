using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TelerikColours.Services.Models;

namespace TelerikColours.Services.Contracts
{
    public interface IFlightService
    {
        IEnumerable<Airport> GetAllAirportsInCity(int cityId);

        IEnumerable<Airline> GetAllAirlines();

        IEnumerable<PresentationFlight> GetFlights(int airlineId, int airlineDestId, DateTime travelDate, int passangersCount);

        IEnumerable<Flight> FilterFlights(string type, string filterExpression);

        Flight GetFlightForUpdate(int id);

        void SaveUpdatedFlight();
    }
}
