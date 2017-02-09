using System;

namespace TelerikColours.CustomEventArgs
{
    public class CitiesCustomEventArgs: EventArgs
    {
        public int CountryId { get; set; }

        public CitiesCustomEventArgs(int countryId)
        {
            this.CountryId = countryId;
        }
    }
}
