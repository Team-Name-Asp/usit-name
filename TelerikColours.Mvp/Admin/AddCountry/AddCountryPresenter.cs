using System;
using TelerikColours.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.AddCountry
{
    public class AddCountryPresenter:Presenter<IAddCountryView>
    {
        private readonly IFactoryService factoryService;

        public AddCountryPresenter(IAddCountryView view, IFactoryService factoryService)
            : base(view)
        {
            if(factoryService == null)
            {
                throw new NullReferenceException("IFactoryService");
            }

            this.factoryService = factoryService;

            this.View.SubmitCountry += View_SubmitCountry;
        }

        private void View_SubmitCountry(object sender, AddCountryCustomEventArgs e)
        {
            this.factoryService.AddCountry(e.Name);
        }
    }
}
