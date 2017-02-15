using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class AutocompleteCustomEventArgs : EventArgs
    {
        public string PrefixText { get; set; }

        public AutocompleteCustomEventArgs(string prefixText)
        {
            this.PrefixText = prefixText;
        }
    }
}
