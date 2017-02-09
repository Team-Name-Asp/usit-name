using System;

namespace TelerikColours.CustomEventArgs
{
    public class AirportsCustomEventArgs: EventArgs
    {
        public int CityId { get; set; }
        public AirportsCustomEventArgs(int cityId)
        {
            this.CityId = cityId;
        }
    }
}
