using System;
using WebFormsMvp;

namespace TelerikColours.App_Start.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
