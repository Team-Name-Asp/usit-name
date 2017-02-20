using Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using TelerikColours.Mvp.Admin.EditFlight;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TelerikColours
{

    [PresenterBinding(typeof(EditFlightPresenter))]
    public partial class EditFlights : MvpPage<EditFlightViewModel>, IEditFlightView
    {
        public event EventHandler<FlightFilterCustomEventArgs> InitFlights;
        public event EventHandler<FlightEditCustomEventArgs> UpdateFlight;
        public event EventHandler CommitChanges;

        protected void Flights_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var filterType = this.FilterExpression.SelectedValue;
            var filterQUery = this.FilterText.Text;
            this.InitFlights?.Invoke(sender, new FlightFilterCustomEventArgs(filterType, filterQUery));

            this.Flights.PageIndex = e.NewPageIndex;
           
            this.Flights_GetData();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //var filterType = this.FilterExpression.SelectedValue;
            //var filterQUery = this.FilterText.Text;
            //this.InitFlights?.Invoke(sender, new FlightSortCustomEventArgs(filterType, filterQUery));

            //this.Flights.DataSource = this.Model.Flights;
            //this.Flights.DataBind();
            this.Flights_GetData();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void Flights_UpdateItem(int id)
        {
            this.UpdateFlight?.Invoke(null, new FlightEditCustomEventArgs(id));

            Flight item = this.Model.UpdatedFlight;

            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.CommitChanges?.Invoke(null, null);
            }
        }


        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Flight> Flights_GetData()
        {
            var filterType = this.FilterExpression.SelectedValue;
            var filterQUery = this.FilterText.Text;

            if (filterType == string.Empty || filterQUery == string.Empty)
            {
                return null;
            }

            this.InitFlights?.Invoke(null, new FlightFilterCustomEventArgs(filterType, filterQUery));

            return this.Model.Flights.AsQueryable<Flight>();
        }
    }
}
