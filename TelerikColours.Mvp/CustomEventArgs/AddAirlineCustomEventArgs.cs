using System;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class AddAirlineCustomEventArgs : EventArgs
    {
        public string Name { get; set; }

        public AddAirlineCustomEventArgs(string name)
        {
            this.Name = name;
        }
    }
}
