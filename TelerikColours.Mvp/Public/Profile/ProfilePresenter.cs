using System;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.Profile
{
    public class ProfilePresenter: Presenter<IProfileView>
    {
        private IUserService userService;

        public ProfilePresenter(IProfileView view, IUserService userService)
            : base(view)
        {
            if(userService == null)
            {
                throw new NullReferenceException("IUserService");
            }

            this.userService = userService;

            this.View.InitFlightHistory += View_InitFlightHistory;
            this.View.InitUpcommingFlights += View_InitUpcommingFlights;
            this.View.InitUpcommingJobs += View_InitUpcommingJobs;
            this.View.InitJobsHistory += View_InitJobsHistory;
        }

        private void View_InitJobsHistory(object sender, UserCustomEventArgs e)
        {
            this.View.Model.JobsHistory = this.userService.GetJobsHistory(e.UserId);
        }

        private void View_InitUpcommingJobs(object sender, UserCustomEventArgs e)
        {
            this.View.Model.UpcommingJobs = this.userService.GetUpcommingJobs(e.UserId);
        }

        private void View_InitUpcommingFlights(object sender, UserCustomEventArgs e)
        {
            this.View.Model.UpcommingFlights = this.userService.GetUpcommingFlights(e.UserId);
        }

        private void View_InitFlightHistory(object sender, UserCustomEventArgs e)
        {
            this.View.Model.FlightHistory = this.userService.GetFlightHistory(e.UserId);
        }
    }
}
