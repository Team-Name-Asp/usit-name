using System;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class FlightFilterCustomEventArgs : EventArgs
    {
        public FlightFilterCustomEventArgs(string sortType, string sortExpression)
        {
            this.SortExpression = sortExpression;
            this.SortType = sortType;
        }

        public string SortType { get; set; }

        public string SortExpression { get; set; }
    }
}

