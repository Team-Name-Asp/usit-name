using System;

namespace TelerikColours.CustomEventArgs
{
    public class AddCountryCustomEventArgs : EventArgs
    {
        public string Name { get; set; }

        public AddCountryCustomEventArgs(string name)
        {
            this.Name = name;
        }
    }
}