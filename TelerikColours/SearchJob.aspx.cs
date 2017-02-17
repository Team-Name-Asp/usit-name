using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.SearchJob;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{
    [PresenterBinding(typeof(SearchJobPresenter))]
    public partial class SearchJob : MvpPage<SearchJobViewModel>, ISearchJobView
    {
        public event EventHandler<SearchJobCustomEventArgs> InitSubmit;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchJobButton_Click(object sender, EventArgs e)
        {
            JobResults_GetData(sender);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Job> JobResults_GetData(object sender)
        {
            if (this.JobSearch.Text == string.Empty)
            {
                return null;
            }

            var searchedTerm = this.JobSearch.Text;
            this.InitSubmit?.Invoke(sender, new SearchJobCustomEventArgs(searchedTerm));

            return this.Model.FoundJobs;
        }
    }
}