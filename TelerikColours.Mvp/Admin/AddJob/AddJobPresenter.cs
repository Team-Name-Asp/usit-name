using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddJob
{
    public class AddJobPresenter : Presenter<IAddJobView>
    {
        private ILocationService locationService;
        private IFactoryService factoryService;

        public AddJobPresenter(IAddJobView view, IFactoryService factoryService, ILocationService locationService) : base(view)
        {
            if (factoryService == null)
            {
                throw new NullReferenceException("IFactoryService");
            }

            if (locationService == null)
            {
                throw new NullReferenceException("ILocationService");
            }

            this.factoryService = factoryService;
            this.locationService = locationService;

            this.View.InitCities += View_InitCities;
            this.View.SubmitAddJob += View_SubmitAddJob;
        }

        private void View_SubmitAddJob(object sender, AddJobCustomEventArgs e)
        {
            this.factoryService.AddJob(e.JobTitle, e.JobDescription, e.Slots, e.StartDate,
                e.EndDate, e.Wage, e.CompanyName, e.Price, e.CityId);
        }

        private void View_InitCities(object sender, EventArgs e)
        {
            this.View.Model.Cities = this.locationService.GetAllCities();

        }
    }
}
