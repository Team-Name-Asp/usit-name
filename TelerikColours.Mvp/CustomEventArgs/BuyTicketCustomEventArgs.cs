using System;
using System.Collections.Generic;
using TelerikColours.Services.Models;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class BuyTicketCustomEventArgs: EventArgs
    {
        public BuyTicketCustomEventArgs(IEnumerable<PresentationFlight>  flights, string userId)
        {
            this.Flights = flights;
            this.UserId = userId;
        }

        public string UserId { get; set; }

        public IEnumerable<PresentationFlight> Flights { get; set; }
    }
}
