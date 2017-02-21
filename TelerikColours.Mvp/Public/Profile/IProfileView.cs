using System;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.Profile
{
    public interface IProfileView: IView<ProfileViewModel>
    {
        event EventHandler<UserCustomEventArgs> InitFlightHistory;
        event EventHandler<UserCustomEventArgs> InitUpcommingFlights;
        event EventHandler<UserCustomEventArgs> InitJobsHistory;
        event EventHandler<UserCustomEventArgs> InitUpcommingJobs;
    }
}
