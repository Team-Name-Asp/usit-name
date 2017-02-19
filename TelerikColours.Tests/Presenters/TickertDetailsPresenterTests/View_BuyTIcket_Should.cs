using NUnit.Framework;

namespace TelerikColours.Tests.Presenters.TickertDetailsPresenterTests
{
    [TestFixture]
    class View_BuyTIcket_Should
    {
        //[Test]
        //public void 

    }
}


//{
//    public class TicketPresenter : Presenter<ITicketDetailsView>
//    {
//        private IUserService userService;

//        public TicketPresenter(ITicketDetailsView view, IUserService userService)
//            : base(view)
//        {
//            if (userService == null)
//            {
//                throw new NullReferenceException("UserService");
//            }

//            this.userService = userService;

//            this.View.BuyTicket += View_BuyTicket;
//        }

//        private void View_BuyTicket(object sender, BuyTicketCustomEventArgs e)
//        {
//            this.userService.BuyTicket(e.UserId, e.Flights);
//        }
//    }
//}
