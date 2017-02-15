using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Ninject;
using TelerikColours.Services.Contracts;

namespace TelerikColours
{
    /// <summary>
    /// Summary description for JobSearchAutocompleteService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class JobSearchAutocompleteService : System.Web.Services.WebService
    {
        [Inject]
        public IJobService JobService { get; set; }

        [WebMethod]
        [ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string[] GetAutocompleteList(string prefixText, int count)
        {
            var todayDate = DateTime.Now;
            var availableJobsTitles = this.JobService.GetAllJobs()
                .Where(j => j.StartDate >= todayDate)
                .Where(j => j.JobTitle.Contains(prefixText))
                .Select(j => j.JobTitle)
                .ToArray();

            return availableJobsTitles;
        }
    }
}
