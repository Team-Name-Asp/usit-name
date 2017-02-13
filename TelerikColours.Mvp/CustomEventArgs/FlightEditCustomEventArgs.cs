using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class FlightEditCustomEventArgs: EventArgs
    {
        public FlightEditCustomEventArgs(int flightId)
        {
            this.FlightId = flightId;
        }
        public int FlightId { get; set; }

    }
}
