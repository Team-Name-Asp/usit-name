using System;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class TicketSalesCustomEventArgs : EventArgs
    {
        public TicketSalesCustomEventArgs(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;

        }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
