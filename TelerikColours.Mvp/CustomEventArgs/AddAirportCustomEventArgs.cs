using System;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class AddAirportCustomEventArgs : EventArgs
    {
        public int CityId { get; set; }

        public string AirportName { get; set; }

        public AddAirportCustomEventArgs(int cityId, string airportName)
        {
            this.CityId = cityId;
            this.AirportName = airportName;
        }
    }
}
