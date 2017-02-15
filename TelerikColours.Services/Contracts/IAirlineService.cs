using System.Collections.Generic;
using Models;

namespace TelerikColours.Services.Contracts
{
    public interface IAirlineService
    {
        IEnumerable<Airline> GetAllAirlines();
    }
}