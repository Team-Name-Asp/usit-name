using Models;
using System;
using System.Web.ModelBinding;
using TelerikColours.Mvp.Admin.FlightDetails;
using WebFormsMvp;
using WebFormsMvp.Web;
using TelerikColours.Mvp.CustomEventArgs;

namespace TelerikColours
{

    [PresenterBinding(typeof(FlightDetailsPresenter))]

    public partial class DetailFlight : MvpPage<FlightDetailsViewModel>, IFlightView
    {
        public event EventHandler<DetailsFlightCustomEventArgs> InitFlight;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Flight FormViewBookDetails_GetItem([QueryString] int id)
        {
          
            this.InitFlight?.Invoke(null, new DetailsFlightCustomEventArgs(id));

            return this.Model.Flight;
        }
    }
}