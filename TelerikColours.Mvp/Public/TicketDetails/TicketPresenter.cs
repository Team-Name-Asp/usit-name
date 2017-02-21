using System;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.TicketDetails
{
    public class TicketPresenter : Presenter<ITicketDetailsView>
    {
        private IUserService userService;

        public TicketPresenter(ITicketDetailsView view, IUserService userService)
            : base(view)
        {
            if(userService == null)
            {
                throw new NullReferenceException("UserService");
            }

            this.userService = userService;

            this.View.BuyTicket += View_BuyTicket;
        }

        private void View_BuyTicket(object sender, BuyTicketCustomEventArgs e)
        {
            this.View.Model.HasEnoughMoney = this.userService.BuyTicket(e.UserId, e.Flights);
        }
    }
}
