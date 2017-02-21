using System;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.TicketSales
{
    public interface ITicketsSalesView: IView<TicketSalesViewModel>
    {
        event EventHandler<TicketSalesCustomEventArgs> InitTickets;
    }
}
