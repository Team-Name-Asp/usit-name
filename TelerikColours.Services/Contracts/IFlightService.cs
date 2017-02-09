using Models;
using System.Collections.Generic;

namespace TelerikColours.Services.Contracts
{
    public interface IFlightService
    {
        IEnumerable<Airport> GetAllAirportsInCity(int cityId);

        IEnumerable<Airline> GetAllAirlines();


        IEnumerable<Flight> GetFlights(int airlineId, int airlineDestId);
    }
}
