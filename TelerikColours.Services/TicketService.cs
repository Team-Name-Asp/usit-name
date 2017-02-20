using System;
using System.Linq;

using TelerikColours.Services.Contracts;
using Models;
using Repositories.Contracts;
using System.Data.Entity;

namespace TelerikColours.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            if (ticketRepository == null)
            {
                throw new NullReferenceException("TicketRepository");
            }

            this.ticketRepository = ticketRepository;
        }

        public IQueryable<Ticket> GetTicketSales(DateTime startPeriod, DateTime endPeriod)
        {
            var tickets = this.ticketRepository.All.Where(t => startPeriod <= t.BoughtDate && t.BoughtDate <= endPeriod).Include(t => t.ApplicationUser);
            return tickets;
        }
    }
}
