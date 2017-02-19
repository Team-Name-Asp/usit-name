using System;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddAirport
{
    public class AddAirportPresenter : Presenter<IAddAirportView>
    {
        private readonly ILocationService locationService;
        private readonly IFactoryService factoryService;

        public AddAirportPresenter(IAddAirportView view, ILocationService locationService, 
            IFactoryService factoryService) : base(view)
        {
            if(locationService == null)
            {
                throw new NullReferenceException("ILocationService");
            }

            if(factoryService == null)
            {
                throw new NullReferenceException("IFactoryService");
            }

            this.locationService = locationService;
            this.factoryService = factoryService;

            this.View.InitCountries += View_InitCountries;
            this.View.SubmitAddAirport += View_AddAirport;
            this.View.InitCities += View_InitCities;
        }

        private void View_InitCities(object sender, CitiesCustomEventArgs e)
        {
            this.View.Model.Cities = this.locationService.GetCityInCountry(e.CountryId);
        }

        private void View_AddAirport(object sender, AddAirportCustomEventArgs e)
        {
            this.factoryService.AddAirport(e.CityId, e.AirportName);
        }

        private void View_InitCountries(object sender, EventArgs e)
        {
            this.View.Model.Countries = this.locationService.GetAllCountries();
        }
    }
}
