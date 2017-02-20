using System;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.Profile
{
    public class ProfilePresenter: Presenter<IProfileView>
    {
        private IUserService userService;

        public ProfilePresenter(IProfileView view, IUserService userService)
            : base(view)
        {
            if(userService == null)
            {
                throw new NullReferenceException("IUserService");
            }

            this.userService = userService;

            this.View.InitFlightHistory += View_InitFlightHistory;
            this.View.InitUpcommingFlights += View_InitUpcommingFlights;
        }

        private void View_InitUpcommingFlights(object sender, UserCustomEventArgs e)
        {
            this.View.Model.UpcommingFlights = this.userService.GetUpcommingFlights(e.UserId);
        }

        private void View_InitFlightHistory(object sender, UserCustomEventArgs e)
        {
            this.View.Model.FlightHistory = this.userService.GetFlightHistory(e.UserId);
        }
    }
}
