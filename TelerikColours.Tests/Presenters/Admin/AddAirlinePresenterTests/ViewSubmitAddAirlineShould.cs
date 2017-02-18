using Moq;
using NUnit.Framework;
using TelerikColours.Mvp.Admin.AddAirline;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.AddAirlinePresenterTests
{
    [TestFixture]
    public class ViewSubmitAddAirlineShould
    {
        [TestCase("FirstName")]
        [TestCase("SecondName")]

        public void Call_AddAirline_OnFactoryService_WithProvidedParameters(string airlineName)
        {
            // Arrange
            var addAirlineViewStub = new Mock<IAddAirlineView>();
            var factoryService = new Mock<IFactoryService>();
            var presenter = new AddAirlinePresenter(addAirlineViewStub.Object, factoryService.Object);
            var addAirlineEventArgs = new AddAirlineCustomEventArgs(airlineName);

            // Act 
            presenter.View_SubmitAddAirline(It.IsAny<object>(), addAirlineEventArgs);

            // Assert
            factoryService.Verify(x => x.AddAirline(It.Is<string>(n => n == airlineName)));
        }
    }
}
