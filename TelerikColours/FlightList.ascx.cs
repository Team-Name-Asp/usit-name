using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TelerikColours
{
    public partial class FlightHistory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                
        }

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

        private IEnumerable<Flight> flightList;

        public IEnumerable<Flight> FlightList
        {
            set
            {
                this.flightList = value;
                this.Flights.DataSource = value.ToList();
                this.Flights.DataBind();
            }
            get
            {
                return this.flightList;
            }
        }
    }
}
