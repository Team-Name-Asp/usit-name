using Microsoft.AspNet.Identity;
using System;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.Profile;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class Profile : MvpPage<ProfileViewModel>, IProfileView
    {
        public event EventHandler<UserCustomEventArgs> InitFlightHistory;
        public event EventHandler<UserCustomEventArgs> InitUpcommingFlights;
        public event EventHandler<UserCustomEventArgs> InitJobsHistory;
        public event EventHandler<UserCustomEventArgs> InitUpcommingJobs;


        protected void FlightHistory_Click(object sender, EventArgs e)
        {
            this.UpcommingFlights.Visible = false;
            this.UpcommingJobs.Visible = false;
            this.JobHistory.Visible = false;

            string currentUserId = User.Identity.GetUserId();
            this.InitFlightHistory?.Invoke(sender, new UserCustomEventArgs(currentUserId));
            this.TheFlightHistory.Heading = "TheFlightHistory";
            this.TheFlightHistory.FlightList = this.Model.FlightHistory;

            this.TheFlightHistory.Visible = true;
        }

        protected void UpFlights_Click(object sender, EventArgs e)
        {
            this.TheFlightHistory.Visible = false;
            this.UpcommingJobs.Visible = false;
            this.JobHistory.Visible = false;

            string currentUserId = User.Identity.GetUserId();
            this.InitUpcommingFlights?.Invoke(sender, new UserCustomEventArgs(currentUserId));
            this.UpcommingFlights.Heading = "Upcomming Flights";
            this.UpcommingFlights.FlightList = this.Model.UpcommingFlights;

            this.UpcommingFlights.Visible = true;

        }

        protected void TheJobHistory_Click(object sender, EventArgs e)
        {
            this.TheFlightHistory.Visible = false;
            this.UpcommingFlights.Visible = false;
            this.UpcommingJobs.Visible = false;

            string currentUserId = User.Identity.GetUserId();
            this.InitJobsHistory?.Invoke(sender, new UserCustomEventArgs(currentUserId));
            this.JobHistory.Heading = "All job offers";
            this.JobHistory.Jobs = this.Model.JobsHistory;

            this.JobHistory.Visible = true;
        }

        protected void UpJobs_Click(object sender, EventArgs e)
        {
            this.TheFlightHistory.Visible = false;
            this.UpcommingFlights.Visible = false;
            this.JobHistory.Visible = false;

            string currentUserId = User.Identity.GetUserId();
            this.InitUpcommingJobs?.Invoke(sender, new UserCustomEventArgs(currentUserId));
            this.UpcommingJobs.Heading = "Upcomming jobs";
            this.UpcommingJobs.Jobs = this.Model.UpcommingJobs;

            this.UpcommingJobs.Visible = true;
        }
    }
}
