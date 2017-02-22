using System;
using System.Web.UI.WebControls;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddAirport;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours.Admin
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
                //this.CountryList.DataBind();
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
            int countryId = 0;

            if (!int.TryParse(this.CountryList.SelectedValue, out countryId))
            {
                //this.CityList.DataSource = null;
                //this.CityList.DataBind();
                //this.CityList.SelectedIndex = 0;
                //this.CityList.Items[0].Text = null;
                //this.CityList.Items[0].Value = null;
                this.CityList.Items.Clear();
                return;
            }

            this.InitCities?.Invoke(sender, new CitiesCustomEventArgs(countryId));

            this.CityList.DataSource = this.Model.Cities;
            this.CityList.DataBind();
        }
    }
}

