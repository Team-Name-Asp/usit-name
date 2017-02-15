using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

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

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat= System.Web.Script.Services.ResponseFormat.Json)]
        public string[] GetAutocompleteList(string prefixText, int count)
        {

            var text = new List<string>();
            text.Add("test");
            text.Add("test2");

            return text.Where(t => t.Contains(prefixText)).ToArray();
        }
    }
}
