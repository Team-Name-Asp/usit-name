using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.SearchJob
{
    public class SearchJobPresenter : Presenter<ISearchJobView>
    {
        private readonly IJobService jobService;

        public SearchJobPresenter(ISearchJobView view, IJobService jobService) : base(view)
        {
            if (jobService == null)
            {
                throw new NullReferenceException("JobService");
            }

            this.jobService = jobService;

            this.View.InitSubmit += View_InitSubmit;
        }

        private void View_InitSubmit(object sender, SearchJobCustomEventArgs e)
        {
            var foundJobs = this.jobService.GetAllJobsFromByTerm(e.SearchedTerm);

            this.View.Model.FoundJobs = foundJobs;
        }
    }
}
