using System;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddCountry;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours.Admin
{
    [PresenterBinding(typeof(AddCountryPresenter))]
    public partial class AddCountry : MvpPage, IAddCountryView
    {
        public event EventHandler<AddCountryCustomEventArgs> SubmitCountry;

        protected void Submit_Click(object sender, EventArgs e)
        {
            string countryName = this.CountryName.Text;

            this.SubmitCountry?.Invoke(sender, new AddCountryCustomEventArgs(countryName));
        }
    }
}
