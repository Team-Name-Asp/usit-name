using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Public.SearchFlight;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{
    [PresenterBinding(typeof(SearchFlightPresenter))]
    public partial class SearchFlight : MvpPage<SearchFlightViewModel>, ISearchFlightView
    {
        public event EventHandler InitCountries;
        public event EventHandler<CitiesCustomEventArgs> InitCitiesFrom;
        public event EventHandler<CitiesCustomEventArgs> InitCitiesTo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.InitCountries?.Invoke(sender, e);

                this.CountryFromList.DataSource = this.Model.CountriesFrom;
                this.CountryFromList.DataBind();


                this.CountryToList.DataSource = this.Model.CountryTo;
                this.CountryToList.DataBind();
            }
        }
        protected void CountryFromList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var countryId = int.Parse(this.CountryFromList.SelectedValue);

            this.InitCitiesFrom?.Invoke(sender, new CitiesCustomEventArgs(countryId));
        }


        protected void CountryToList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var countryId = int.Parse(this.CountryFromList.SelectedValue);

            this.InitCitiesTo?.Invoke(sender, new CitiesCustomEventArgs(countryId));
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

        }
    }
}