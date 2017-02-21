using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.JobDetails
{
    public class JobDetailsPresenter : Presenter<IJobDetailsView>
    {
        private readonly IJobService jobService;
        private readonly IUserService userService;

        public JobDetailsPresenter(IJobDetailsView view, IJobService jobService, IUserService userService) : base(view)
        {
            if (jobService == null)
            {
                throw new NullReferenceException("IJobService");
            }

            if (userService == null)
            {
                throw new NullReferenceException("IUserService");
            }

            this.jobService = jobService;
            this.userService = userService;

            this.View.InitJob += View_InitJob;
            this.View.EnrollJob += View_EnrollJob;
        }

        private void View_EnrollJob(object sender, EnrollJobCustomEventArgs e)
        {
            var jobToEnroll = this.jobService.GetJobById(e.JobId);

            this.userService.AttachJobToUser(e.UserId, jobToEnroll);
        }

        public void View_InitJob(object sender, JobDetailsCustomEventArgs e)
        {
            var foundJob = this.jobService.GetJobById(e.JobId);

            this.View.Model.FoundJob = foundJob;
        }
    }
}
