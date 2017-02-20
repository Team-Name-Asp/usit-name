using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using TelerikColours.Data;

namespace TelerikColours
{
    public partial class JobDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Models.Job FormViewJobDetails_GetItem([QueryString] int id)
        {
            // testing
            var context = new TelerikColoursDbContext();
            return context.Jobs.First(j => j.Id == id);
        }
    }
}