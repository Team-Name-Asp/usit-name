using System;
using System.Web.ModelBinding;
using TelerikColours.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace TelerikColours.Mvp.Admin.EditFlight
{
    public interface IEditFlightView: IView<EditFlightViewModel>
    {
        event EventHandler<FlightFilterCustomEventArgs> InitFlights;
        event EventHandler<FlightEditCustomEventArgs> UpdateFlight;
       // event EventHandler CommitChanges;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
