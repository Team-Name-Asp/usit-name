using System;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddJob
{
    public interface IAddJobView: IView<AddJobViewModel>
    {
        event EventHandler InitCities;

        event EventHandler<AddJobCustomEventArgs> SubmitAddJob;
    }
}
