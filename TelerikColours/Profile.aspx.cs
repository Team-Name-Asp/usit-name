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

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void FlightHistory_Click(object sender, EventArgs e)
        {
            this.UpcommingFlights.Visible = false;
            string currentUserId = User.Identity.GetUserId();
            this.InitFlightHistory?.Invoke(sender, new UserCustomEventArgs(currentUserId));
            TheFlightHistory.Heading = "TheFlightHistory";
            TheFlightHistory.FlightList = this.Model.FlightHistory;
            this.TheFlightHistory.Visible = true;
        }

        protected void UpFlights_Click(object sender, EventArgs e)
        {
            this.TheFlightHistory.Visible = false;
            string currentUserId = User.Identity.GetUserId();
            this.InitUpcommingFlights?.Invoke(sender, new UserCustomEventArgs(currentUserId));
            UpcommingFlights.Heading = "Upcomming Flights";
            UpcommingFlights.FlightList = this.Model.UpcommingFlights;
            this.UpcommingFlights.Visible = true;

        }
    }
}
//Control myForm = Page.FindControl("Form1");
//Listing07_04 c1 = (Listing07_04)LoadControl("Listing07-04.ascx"); myForm.Controls.Add(c1);
//c1.ID = "Listing07_04";
//c1.Text = "Text about our custom user control.";