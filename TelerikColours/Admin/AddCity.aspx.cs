using System;
using System.Web.UI;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddCity;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours.Admin
{
    [PresenterBinding(typeof(AddCityPresenter))]
    public partial class AddCity : MvpPage<AddCityViewModel>, IAddCityView
    {
        public event EventHandler InitCountries;
        public event EventHandler<AddCityCustomEventArgs> SubmitAddCity;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.InitCountries?.Invoke(sender, e);

                this.CountriesList.DataSource = this.Model.Countries;
                this.CountriesList.DataBind();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int countryId = int.Parse(this.CountriesList.SelectedValue);
            string cityName = this.CityName.Text;

            this.SubmitAddCity?.Invoke(sender, new AddCityCustomEventArgs(countryId, cityName));
        }
    }
}
