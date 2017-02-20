using Models;
using System;
using System.Linq;
using TelerikColours.Mvp.Admin.TicketSales;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{

    [PresenterBinding(typeof(TicketSalesPresenter))]

    public partial class TicketSales : MvpPage<TicketSalesViewModel>, ITIcketsSalesView
    {
        public event EventHandler<TicketSalesCustomEventArgs> InitTickets;

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void Tickets_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            this.Tickets.PageIndex = e.NewPageIndex;
            var startDate = DateTime.Parse(this.Startdate.Text);
            var endDate = DateTime.Parse(this.EndDate.Text);

            this.InitTickets?.Invoke(sender, new TicketSalesCustomEventArgs(startDate, endDate));

            this.Tickets_GetData();

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var startDate = DateTime.Parse(this.Startdate.Text);
            var endDate = DateTime.Parse(this.EndDate.Text);

            this.InitTickets?.Invoke(sender, new TicketSalesCustomEventArgs(startDate, endDate));


            this.Tickets_GetData();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Ticket> Tickets_GetData()
        {

            return this.Model.Tickets;
        }
    }
}