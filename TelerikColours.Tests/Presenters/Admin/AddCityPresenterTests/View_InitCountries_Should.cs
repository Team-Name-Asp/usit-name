using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.Admin.AddCity;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddCityPresenterTests
{
    [TestFixture]
    public class View_InitCountries_Should
    {
        [Test]
        public void SetCountriesOnViewModelWithExpectedCollection_WhenInitCountriesEventIsRaised()
        {
            // Arrange
            var viewStub = new Mock<IAddCityView>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var locationServiceStub = new Mock<ILocationService>();
            var presenter = new AddCityPresenter(viewStub.Object, factoryServiceStub.Object, locationServiceStub.Object);

            // Act
            
            // Assert
        }
    }
}
//private void View_InitCountries(object sender, EventArgs e)
//{
//    this.View.Model.Countries = this.locationService.GetAllCountries();
//}