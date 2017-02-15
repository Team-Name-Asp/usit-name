using System.Collections.Generic;
using Models;

namespace TelerikColours.Services.Contracts
{
    public interface IAirportService
    {
        IEnumerable<Airport> GetAllAirportsInCity(int cityId);
    }
}