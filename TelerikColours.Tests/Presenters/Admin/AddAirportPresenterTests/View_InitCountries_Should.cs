using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TelerikColours.Mvp.Admin.AddAirport;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddAirportPresenterTests
{
    [TestFixture]
    public class View_InitCountries_Should
    {
        [Test]
        public void AddCoutriesToViewModel_WhenInitCountriesEventIsRaised()
        {
            // Arrange
            var locationServiceMock = new Mock<ILocationService>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var viewMock = new Mock<IAddAirportView>();

            var addAirportPresenter = new AddAirportPresenter(viewMock.Object, locationServiceMock.Object, factoryServiceStub.Object);
            viewMock.Setup(v => v.Model).Returns(new AddAirportViewModel());

            var expectedCountries = new List<Country>()
            {
                new Country("FirstCOuntry"),
                new Country("SecondCountry")
            };

            locationServiceMock.Setup(l => l.GetAllCountries()).Returns(expectedCountries);

            // Act
            viewMock.Raise(v => v.InitCountries += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(expectedCountries, viewMock.Object.Model.Countries);
        }
    }
}
