using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TelerikColours.Services.Models;

namespace TelerikColours.Services.Contracts
{
    public interface IFlightService
    {
        IEnumerable<PresentationFlight> GetFlights(int airlineId, int airlineDestId, DateTime travelDate, int passangersCount);

        IQueryable<Flight> FilterFlights(string type, string filterExpression);

        Flight GetFlightForUpdate(int id);

        void SaveUpdatedFlight();

        IEnumerable<Flight> GetCheapestFlights();
    }
}
