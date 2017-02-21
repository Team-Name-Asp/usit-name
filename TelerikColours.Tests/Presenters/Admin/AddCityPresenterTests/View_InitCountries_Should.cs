using Models;
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
            var viewMock = new Mock<IAddCityView>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var locationServiceStub = new Mock<ILocationService>();
            var presenter = new AddCityPresenter(viewMock.Object, factoryServiceStub.Object, locationServiceStub.Object);

            viewMock.Setup(v => v.Model).Returns(new AddCityViewModel());

            var expectedCountries = new List<Country>()
            {
                new Country(),
                new Country()
            };

            locationServiceStub.Setup(l => l.GetAllCountries()).Returns(expectedCountries);
            // Act
            viewMock.Raise(v => v.InitCountries += null, EventArgs.Empty);

            // Assert

            CollectionAssert.AreEqual(expectedCountries, viewMock.Object.Model.Countries);
        }
    }
}

