using Moq;
using NUnit.Framework;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddCity;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddCityPresenterTests
{
    [TestFixture]
    public class View_SubmitAddCity_Should
    {
        [TestCase(23, "Sofia")]
        [TestCase(1, "BurgaskaBatka")]
        public void CallAddCityOnFactoryServiceWithExpectedParameters_WhenSubmitAddCityEventIsInvoked(int countryId, string cityName)
        {
            // Arrange
            var viewStub = new Mock<IAddCityView>();
            var factoryServiceMock = new Mock<IFactoryService>();
            var locationServiceStub = new Mock<ILocationService>();
            var presenter = new AddCityPresenter(viewStub.Object, factoryServiceMock.Object, locationServiceStub.Object);

            var addCityCustomEventArgs = new AddCityCustomEventArgs(countryId, cityName);

            // Act
            viewStub.Raise(v => v.SubmitAddCity += null, addCityCustomEventArgs);

            // Assert
            factoryServiceMock.Verify(f => f.AddCity(It.Is<int>(cId => cId == countryId), It.Is<string>(name => name == cityName)), Times.Once);
        }
    }
}

