using System;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class SearchCitiesForFlightCustomEventArgs: EventArgs
    {
        public string SourceCity { get; set; }

        public SearchCitiesForFlightCustomEventArgs(string sourceCity)
        {
            this.SourceCity = sourceCity;
        }
    }
}
