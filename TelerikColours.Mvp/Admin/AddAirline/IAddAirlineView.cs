using System;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddAirline
{
    public interface IAddAirlineView : IView
    {
        event EventHandler<AddAirlineCustomEventArgs> SubmitAddAirline;
    }
}
