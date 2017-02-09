using System;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddAirline
{
    public class AddAirlinePresenter : Presenter<IAddAirlineView>
    {
        private IFactoryService factoryService;

        public AddAirlinePresenter(IAddAirlineView view, IFactoryService factoryService) : base(view)
        {
            if(factoryService == null)
            {
                throw new NullReferenceException("IFactoryService");
            }

            this.factoryService = factoryService;

            this.View.SubmitAddAirline += View_SubmitAddAirline;
        }

        private void View_SubmitAddAirline(object sender, CustomEventArgs.AddAirlineCustomEventArgs e)
        {
            string airlineName = e.Name;

            this.factoryService.AddAirline(airlineName);
        }
    }
}
