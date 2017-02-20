using System;
using System.Web.UI.WebControls;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddFlight;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{
    [PresenterBinding(typeof(AddFlightPresenter))]
    public partial class AddFlight : MvpPage<FlightViewModel>, ICreateFlightVliew 
    {
        public event EventHandler<CreateFlightCustomEventArgs> CreateFlight;
        public event EventHandler<AirportsCustomEventArgs> GetAllAirportsFrom;
        public event EventHandler<AirportsCustomEventArgs> GetAllAirportsTo;
        public event EventHandler<CitiesCustomEventArgs> GetAllCitiesFrom;
        public event EventHandler<CitiesCustomEventArgs> GetAllCitiesTo;
        public event EventHandler InitialLoad;
        
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.InitialLoad?.Invoke(sender, e);

                this.CountryFromList.DataSource = this.Model.CountryFromList;
                this.CountryFromList.DataBind();

                this.CountryToList.DataSource = this.Model.CountryToList;
                this.CountryToList.DataBind();

                this.AirlineList.DataSource = this.Model.AirlineList;
                this.AirlineList.DataBind();
            }

        }

        protected void CityFromList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = int.Parse(this.CityFromList.SelectedValue);
            this.GetAllAirportsFrom?.Invoke(sender, new AirportsCustomEventArgs(cityId));

            this.AirportFromList.DataSource = this.Model.AirportFromList;
            this.AirportFromList.DataBind();
        }

        protected void CountryToList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryId = int.Parse(this.CountryToList.SelectedValue);
            this.GetAllCitiesTo?.Invoke(sender, new CitiesCustomEventArgs(countryId));

            this.CityToList.DataSource = this.Model.CityToList;
            this.CityToList.DataBind();
        }

        protected void CityToList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = int.Parse(this.CityToList.SelectedValue);
            this.GetAllAirportsTo?.Invoke(sender, new AirportsCustomEventArgs(cityId));

            this.AirportToList.DataSource = this.Model.AirportToList;
            this.AirportToList.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int departureAirportId = int.Parse(this.AirportFromList.SelectedValue);
            int arrivalAirportId = int.Parse(this.AirportToList.SelectedValue);
            decimal price = decimal.Parse(this.Price.Text);
            DateTime departureDate = DateTime.Parse(this.DateDeparture.Text);
            DateTime arrivalDate = DateTime.Parse(this.ArrivalDate.Text);
            int airlineId = int.Parse(this.AirlineList.SelectedValue);
            int availableSeats = int.Parse(this.Seats.Text);

            this.CreateFlight?.Invoke(sender, new CreateFlightCustomEventArgs(departureAirportId, arrivalAirportId, price, departureDate, arrivalDate, airlineId, availableSeats));
        }

        protected void CountryFromList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryId = int.Parse(this.CountryFromList.SelectedValue);
            this.GetAllCitiesFrom?.Invoke(sender, new CitiesCustomEventArgs(countryId));

            this.CityFromList.DataSource = this.Model.CityFromList;
            this.CityFromList.DataBind();
        }
    }
}