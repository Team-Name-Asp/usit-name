using System;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.Home
{
    public class HomePresenter : Presenter<IHomeView>
    {
        IFlightService flightService;

        public HomePresenter(IHomeView view, IFlightService flightService)
            : base(view)
        {
            if (flightService == null)
            {
                throw new NullReferenceException("IFlightService");
            }

            this.flightService = flightService;
            this.View.InitialLoad += View_InitialLoad;
        }

        private void View_InitialLoad(object sender, EventArgs e)
        {
            var flights = this.flightService.GetCheapestFlights();
            this.View.Model.CheapestFlights = flights;
        }
    }
}
