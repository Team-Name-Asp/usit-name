using Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace TelerikColours.Controls
{
    public partial class JobList : System.Web.UI.UserControl
    {
        public string Heading
        {
            get
            {
                return this.Type.Text;
            }
            set
            {
                this.Type.Text = value;
            }
        }

        private IEnumerable<Job> jobList;


        public IEnumerable<Job> Jobs
        {
            set
            {
                this.jobList = value;
                this.JobsLV.DataSource = value.ToList();
                this.JobsLV.DataBind();
            }
            get
            {
                return this.jobList;
            }
        }
    }
}
