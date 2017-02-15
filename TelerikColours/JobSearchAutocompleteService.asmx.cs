using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Ninject;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.SearchJob;
using TelerikColours.Services.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;

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
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        //public string[] GetAutocompleteList(string prefixText, int count)
        //{
           
        //        this.InitWords?.Invoke(null, e);

        //        return this.Model.InitWords;
              
        //}
    }
}
