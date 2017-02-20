using System;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.TicketSales
{
    public class TicketSalesPresenter : Presenter<ITIcketsSalesView>
    {
        private readonly ITicketService ticketService;

        public TicketSalesPresenter(ITIcketsSalesView view, ITicketService ticketService)
            : base(view)
        {
            if(ticketService == null)
            {
                throw new NullReferenceException("ITicketService");
            }

            this.ticketService = ticketService;

            this.View.InitTickets += View_InitTickets;
        }

        private void View_InitTickets(object sender, TicketSalesCustomEventArgs e)
        {
            this.View.Model.Tickets = this.ticketService.GetTicketSales(e.StartDate, e.EndDate);
        }
    }
}
