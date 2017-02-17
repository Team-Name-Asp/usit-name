using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class SearchJobCustomEventArgs : EventArgs
    {
        public string SearchedTerm { get; set; }

        public SearchJobCustomEventArgs(string searchedTerm)
        {
            this.SearchedTerm = searchedTerm;
        }
    }
}
