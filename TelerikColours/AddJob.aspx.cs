using System;
using System.Web.UI.WebControls;
using TelerikColours.Mvp.Admin.AddJob;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{
    [PresenterBinding(typeof(AddJobPresenter))]
    public partial class AddJob : MvpPage<AddJobViewModel>, IAddJobView
    {
        public event EventHandler InitCities;
        public event EventHandler<AddJobCustomEventArgs> SubmitAddJob;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.InitCities?.Invoke(sender, e);

                this.CityList.DataSource = this.Model.Cities;
                this.CityList.DataBind();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupRequired");
            int cityId = int.Parse(this.CityList.SelectedValue);
            string jobTitle = this.JobTitle.Text;
            string jobDescription = this.JobDescription.Text;
            int slots = int.Parse(this.AvailableSlots.Text);
            var startDate = DateTime.Parse(this.StartDate.Text);
            var endDate = DateTime.Parse(this.EndDate.Text);
            decimal wage = decimal.Parse(this.Wage.Text);
            string companyName = this.CompanyName.Text;
            decimal price = decimal.Parse(this.Price.Text);


            this.SubmitAddJob?.Invoke(sender, new AddJobCustomEventArgs(cityId, jobTitle, jobDescription, slots,
                startDate, endDate, wage, companyName, price));
        }

        protected void ValidateDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Now;
            DateTime maxDate = DateTime.Parse("9999/12/28");
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }
    }
}