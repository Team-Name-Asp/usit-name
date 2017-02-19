using System;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.TicketDetails
{
    public interface ITicketDetailsView: IView
    {
        event EventHandler<BuyTicketCustomEventArgs> BuyTicket;
    }
}
