using System;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.TicketSales
{
    public interface ITIcketsSalesView: IView<TicketSalesViewModel>
    {
        event EventHandler<TicketSalesCustomEventArgs> InitTickets;
    }
}
