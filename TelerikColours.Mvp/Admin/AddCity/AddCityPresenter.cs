using System;
using TelerikColours.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddCity
{
    public class AddCityPresenter : Presenter<IAddCityView>
    {
        private ILocationService locationService;
        private IFactoryService factoryService;

        public AddCityPresenter(IAddCityView view, IFactoryService factoryService, ILocationService locationService)
            : base(view)
        {
            if(factoryService == null)
            {
                throw new NullReferenceException("IFactoryService");
            }

            if(locationService == null)
            {
                throw new NullReferenceException("ILocationService");
            }

            this.factoryService = factoryService;
            this.locationService = locationService;

            this.View.InitCountries += View_InitCountries;
            this.View.SubmitAddCity += View_SubmitAddCity;
        }

        private void View_SubmitAddCity(object sender, AddCityCustomEventArgs e)
        {
            this.factoryService.AddCity(e.CountryId, e.CityName);
        }

        private void View_InitCountries(object sender, EventArgs e)
        {
           this.View.Model.Countries =  this.locationService.GetAllCountries();
            
        }
    }
}
