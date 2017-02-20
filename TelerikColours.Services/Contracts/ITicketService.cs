using System;
using System.Linq;
using Models;

namespace TelerikColours.Services.Contracts
{
    public interface ITicketService
    {
        IQueryable<Ticket> GetTicketSales(DateTime startPeriod, DateTime endPeriod);
    }
}