using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TelerikColours.Mvp.Public.Home;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class _Default : MvpPage<HomeViewModel>, IHomeView
    {
        public event EventHandler InitialLoad;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.InitialLoad?.Invoke(sender, e);

                this.CheapestFlights.DataSource = this.Model.CheapestFlights;
                this.SoonestJobs.DataSource = this.Model.SoonestJobs;
                this.SoonestJobs.DataBind();
                this.CheapestFlights.DataBind();
            }
        }
    }
}