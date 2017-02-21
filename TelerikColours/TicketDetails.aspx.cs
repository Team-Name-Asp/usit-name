﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using TelerikColours.Auth;
using TelerikColours.Mvp.Public.TicketDetails;
using WebFormsMvp;
using WebFormsMvp.Web;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Models;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TelerikColours
{
    [PresenterBinding(typeof(TicketPresenter))]
    public partial class TicketDetails : MvpPage<TicketDetailsViewModel>, ITicketDetailsView
    {
        public event EventHandler<BuyTicketCustomEventArgs> BuyTicket;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["TicketOffer"] != null)
            {
                this.Flights.DataSource = Session["TicketOffer"];
                this.Flights.DataBind();
            }


        }

        protected void Information_Click(object sender, EventArgs e)
        {
            
            if (User.Identity.IsAuthenticated)
            {
                string currentUserId = User.Identity.GetUserId();

                var flights = (IEnumerable<PresentationFlight>)Session["TicketOffer"];
                this.BuyTicket?.Invoke(sender, new BuyTicketCustomEventArgs(flights, currentUserId));

                if(!this.Model.HasEnoughMoney)
                {
                    this.Buy.Visible = false;
                    this.Success.Text = "Not sufficient money";
                }
            }
            else
            {
                // Set the url to .. 
                Response.Redirect("/Account/Login");
            }
        }
    }
}