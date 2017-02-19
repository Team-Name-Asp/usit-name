using Moq;
using NUnit.Framework;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddAirport;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddAirportPresenterTests
{
    [TestFixture]
    public class View_AddAIrport_Should
    {
        [TestCase(221, "Name 1")]
        [TestCase(1, "Name 2")]

        public void CallAddAirportOnFactoryServiceWithExpectedParameters_WhenSubmitAddAirportIsRaised(int cityId, string airportName)
        {
            // Arrange
            var locationServiceMock = new Mock<ILocationService>();
            var factoryServiceMock = new Mock<IFactoryService>();
            var viewMock = new Mock<IAddAirportView>();

            var addAirportPresenter = new AddAirportPresenter(viewMock.Object, locationServiceMock.Object, factoryServiceMock.Object);
            viewMock.Setup(v => v.Model).Returns(new AddAirportViewModel());

            var addAirportCustmEventARgs = new AddAirportCustomEventArgs(cityId, airportName);

            // Act
            viewMock.Raise(v => v.SubmitAddAirport += null, addAirportCustmEventARgs);

            // Assert
            factoryServiceMock.Verify(x => x.AddAirport(It.Is<int>(cId => cId == cityId), It.Is<string>(name => name == airportName)), Times.Once);
        }
    }
}
