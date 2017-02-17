using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.SearchJob
{
    public interface ISearchJobView : IView<SearchJobViewModel>
    {
        event EventHandler<SearchJobCustomEventArgs> InitSubmit;
    }
}
