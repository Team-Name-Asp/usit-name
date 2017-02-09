using System;
using TelerikColours.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddCity
{
    public interface IAddCityView: IView<AddCityViewModel>
    {
        event EventHandler InitCountries;

        event EventHandler<AddCityCustomEventArgs> SubmitAddCity;
    }
}
