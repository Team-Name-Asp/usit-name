using System;
using WebFormsMvp;

namespace TelerikColours.Mvp.Public.Home
{
    public interface IHomeView : IView<HomeViewModel>
    {
        event EventHandler InitialLoad;
    }
}
