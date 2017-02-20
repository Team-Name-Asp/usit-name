using Models;
using System.Linq;

namespace TelerikColours.Mvp.Admin.TicketSales
{
    public class TicketSalesViewModel
    {
        public IQueryable<Ticket> Tickets { get; set; }
    }
}
