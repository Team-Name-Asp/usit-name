using Models;
using System.Collections.Generic;
using System.Linq;
using TelerikColours.Services.Models;

namespace TelerikColours.Services.Contracts
{
    public interface IUserService
    {
        bool BuyTicket(string userId, IEnumerable<PresentationFlight> flights);

        IEnumerable<Flight> GetFlightHistory(string userId);

        IEnumerable<Flight> GetUpcommingFlights(string userId);
    }
}