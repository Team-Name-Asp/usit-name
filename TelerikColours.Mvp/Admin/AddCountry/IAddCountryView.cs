using System;
using TelerikColours.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddCountry
{
    public interface IAddCountryView: IView
    {
        event EventHandler<AddCountryCustomEventArgs> SubmitCountry;
    }
}
