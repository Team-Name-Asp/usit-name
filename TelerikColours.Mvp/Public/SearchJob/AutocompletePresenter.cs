using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.SearchJob
{
    public class AutocompletePresenter : Presenter<IAutocompleteView>
    {
        private readonly IJobService jobService;

        public AutocompletePresenter(IAutocompleteView view, IJobService jobService) : base(view)
        {
            this.jobService = jobService;

            this.View.InitWords += View_InitWords;
        }

        private void View_InitWords(object sender, AutocompleteCustomEventArgs e)
        {
            var todayDate = DateTime.Now;
            this.View.Model.AutocompleteWords = this.jobService.GetAllJobs()
                .Where(j => j.StartDate >= todayDate)
                .Where(j => j.JobTitle.Contains(e.PrefixText))
                .Select(j => j.JobTitle)
                .ToArray();
        }
    }
}
