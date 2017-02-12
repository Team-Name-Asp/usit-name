using System;
using System.Web.UI.WebControls;
using TelerikColours.Mvp.Admin.AddJob;
using WebFormsMvp;

namespace TelerikColours
{
    [PresenterBinding(typeof(AddJobPresenter))]
    public partial class AddJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupRequired");
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