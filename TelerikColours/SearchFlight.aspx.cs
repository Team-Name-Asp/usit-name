using System;
using System.Linq;
using System.Web.UI;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.CustomEventArgs;
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
        public event EventHandler<SearchFlightCustomEventArgs> InitSubmit;
        public event EventHandler<AirportsCustomEventArgs> InitAirportDeparture;
        public event EventHandler<AirportsCustomEventArgs> InitAirportArival;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.InitCountries?.Invoke(sender, e);

                this.CountryFromList.DataSource = this.Model.CountriesFrom;
                this.CountryFromList.DataBind();


                this.CountryToList.DataSource = this.Model.CountriesTo;
                this.CountryToList.DataBind();
            }
        }
        protected void CountryFromList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var countryId = int.Parse(this.CountryFromList.SelectedValue);

            this.InitCitiesFrom?.Invoke(sender, new CitiesCustomEventArgs(countryId));
            this.CityFromList.DataSource = this.Model.CitiesFrom;
            this.CityFromList.DataBind();
        }


        protected void CountryToList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var countryId = int.Parse(this.CountryToList.SelectedValue);

            this.InitCitiesTo?.Invoke(sender, new CitiesCustomEventArgs(countryId));

            this.CityToList.DataSource = this.Model.CitiesTo;
            this.CityToList.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var departureAirportId = int.Parse(this.DepartureAirport.SelectedValue);
            var arivalAirport = int.Parse(this.ArivalAirport.SelectedValue);
            var date = DateTime.Parse(this.DateDeparture.Text);
            var passangersCount = int.Parse(this.Count.Text);

            this.InitSubmit?.Invoke(sender, new SearchFlightCustomEventArgs(departureAirportId, arivalAirport, date, passangersCount));

            this.Flights.DataSource = this.Model.Flights;
            this.Flights.DataBind();

            this.TotalPrice.InnerText = this.Model.Flights.Sum(x => x.Price).ToString();
            this.LabelTotalPrice.InnerText = "Total Price";

            Session["TicketOffer"] = this.Model.Flights;
            Session["PassangerCount"] = this.Count.Text;
        }

        protected void CityFromList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = int.Parse(this.CityFromList.SelectedValue);
            this.InitAirportDeparture?.Invoke(sender, new AirportsCustomEventArgs(cityId));

            this.DepartureAirport.DataSource = this.Model.AirportsDeparture;
            this.DepartureAirport.DataBind();
        }

        protected void CityToList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = int.Parse(this.CityToList.SelectedValue);
            this.InitAirportArival?.Invoke(sender, new AirportsCustomEventArgs(cityId));

            this.ArivalAirport.DataSource = this.Model.AirportArival;
            this.ArivalAirport.DataBind();
        }
    }
}