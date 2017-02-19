using System;
using System.Web.UI;
using TelerikColours.Mvp.Public.Home;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class Home : MvpPage<HomeViewModel>, IHomeView
    {
        public event EventHandler InitialLoad;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.InitialLoad?.Invoke(sender, e);

                this.CheapestFlights.DataSource = this.Model.CheapestFlights;
                this.CheapestFlights.DataBind();
            }
        }
    }
}