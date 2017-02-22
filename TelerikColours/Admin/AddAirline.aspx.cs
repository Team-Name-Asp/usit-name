using System;
using TelerikColours.Mvp.Admin.AddAirline;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours.Admin
{
    [PresenterBinding(typeof(AddAirlinePresenter))]
    public partial class AddAirline : MvpPage, IAddAirlineView
    {
        public event EventHandler<AddAirlineCustomEventArgs> SubmitAddAirline;

        protected void Submit_Click(object sender, EventArgs e)
        {
            string airlineName = this.AirlineName.Text;
            this.SubmitAddAirline?.Invoke(sender, new AddAirlineCustomEventArgs(airlineName));
        }
    }
}