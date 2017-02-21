using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using TelerikColours.Data;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.JobDetails;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{
    [PresenterBinding(typeof(JobDetailsPresenter))]
    public partial class JobDetails : MvpPage<JobDetailsViewModel>, IJobDetailsView
    {
        public event EventHandler<JobDetailsCustomEventArgs> InitJob;
        public event EventHandler<EnrollJobCustomEventArgs> EnrollJob;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Models.Job FormViewJobDetails_GetItem([QueryString] int id)
        {
            this.InitJob?.Invoke(null, new JobDetailsCustomEventArgs(id));

            return this.Model.FoundJob;
        }

        protected void EnrollJob_Click(object sender, EventArgs e)
        {
           
            if (User.Identity.IsAuthenticated)
            {
                string currentUserId = User.Identity.GetUserId();

                var jobId = int.Parse(Request.QueryString["id"]);

                this.EnrollJob?.Invoke(sender, new EnrollJobCustomEventArgs(currentUserId, jobId));
            }
            else
            {
                Response.Redirect("/Account/Login");
            }
        }
    }
}
