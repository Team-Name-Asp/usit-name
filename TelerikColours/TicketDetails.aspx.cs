using System;

namespace TelerikColours
{
    public partial class TicketDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["TicketOffer"] != null)
            {
                this.Flights.DataSource = Session["TicketOffer"];
                this.Flights.DataBind();

                this.PassangerCount.Text = (string)this.Session["PassangerCount"];
            }


        }
    }
}