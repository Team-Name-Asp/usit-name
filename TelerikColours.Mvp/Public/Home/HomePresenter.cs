using System;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.Home
{
    public class HomePresenter : Presenter<IHomeView>
    {
        IFlightService flightService;
        IJobService jobService;

        public HomePresenter(IHomeView view, IFlightService flightService, IJobService jobService)
            : base(view)
        {
            if (flightService == null)
            {
                throw new NullReferenceException("IFlightService");
            }

            if (jobService == null)
            {
                throw new NullReferenceException("IJobService");
            }

            this.flightService = flightService;
            this.jobService = jobService;
            this.View.InitialLoad += View_InitialLoad;
        }

        private void View_InitialLoad(object sender, EventArgs e)
        {
            var flights = this.flightService.GetCheapestFlights();
            var jobs = this.jobService.GetSoonestJobs();
            this.View.Model.CheapestFlights = flights;
            this.View.Model.SoonestJobs = jobs;
        }
    }
}
