using System.Collections.Generic;
using TelerikColours.Services.Models;

namespace TelerikColours.Services.Contracts
{
    public interface IUserService
    {
        bool BuyTicket(string userId, IEnumerable<PresentationFlight> flights);
    }
}