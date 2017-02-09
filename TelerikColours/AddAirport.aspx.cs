using System;
using System.Web.UI.WebControls;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddAirport;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{
    [PresenterBinding(typeof(AddAirportPresenter))]
    public partial class AddAirport : MvpPage<AddAirportViewModel>, IAddAirportView
    {
        public event EventHandler<CitiesCustomEventArgs> InitCities;
        public event EventHandler InitCountries;
        public event EventHandler<AddAirportCustomEventArgs> SubmitAddAirport;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.InitCountries?.Invoke(sender, e);

                this.CountryList.DataSource = this.Model.Countries;
                this.CountryList.DataBind();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int cityId = int.Parse(this.CityList.SelectedValue);
            string airportName = this.AirportName.Text;

            this.SubmitAddAirport?.Invoke(sender, new AddAirportCustomEventArgs(cityId, airportName));
        }

        protected void CountryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryId = int.Parse(this.CountryList.SelectedValue);

            this.InitCities?.Invoke(sender, new CitiesCustomEventArgs(countryId));

            this.CityList.DataSource = this.Model.Cities;
            this.CityList.DataBind();
        }
    }
}

