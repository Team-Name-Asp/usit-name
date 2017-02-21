using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TelerikColours.Mvp.Public.SearchFlight;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.SearchFlightPresenterTests
{
    [TestFixture]
    public class View_InitCountriesShould
    {
        private IEnumerable<Country> expectedCollection = new List<Country> { new Country("firstName"), new Country("SecondName") };

        [Test]
        public void SetCoutriesFrom_OnViewModel_WithExpectedCollection()
        {
            // Arrange
            var viewMock = new Mock<ISearchFlightView>();
            var locationServiceStub = new Mock<ILocationService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServicStub = new Mock<IAirportService>();

            var presenter = new SearchFlightPresenter(viewMock.Object, flightServiceStub.Object, locationServiceStub.Object, airportServicStub.Object);
            viewMock.Setup(x => x.Model).Returns(new SearchFlightViewModel());
            locationServiceStub.Setup(x => x.GetAllCountries()).Returns(this.expectedCollection);

            // Act
            presenter.View_InitCountries(It.IsAny<object>(), It.IsAny<EventArgs>());

            // Assert
            CollectionAssert.AreEqual(this.expectedCollection, viewMock.Object.Model.CountriesFrom);
        }

        [Test]
        public void SetCoutriesTo_OnViewModel_WithExpectedCollection()
        {
            // Arrange
            var viewMock = new Mock<ISearchFlightView>();
            var locationServiceStub = new Mock<ILocationService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServicStub = new Mock<IAirportService>();

            var presenter = new SearchFlightPresenter(viewMock.Object, flightServiceStub.Object, locationServiceStub.Object, airportServicStub.Object);

            viewMock.Setup(x => x.Model).Returns(new SearchFlightViewModel());
            locationServiceStub.Setup(x => x.GetAllCountries()).Returns(this.expectedCollection);

            // Act
            presenter.View_InitCountries(It.IsAny<object>(), It.IsAny<EventArgs>());

            // Assert
            CollectionAssert.AreEqual(this.expectedCollection, viewMock.Object.Model.CountriesTo);
        }

        [Test]
        public void Call_GetAllCountries_OnLocationService_Once()
        {
            // Arrange
            var viewStub = new Mock<ISearchFlightView>();
            var locationServiceMock = new Mock<ILocationService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServicStub = new Mock<IAirportService>();

            var presenter = new SearchFlightPresenter(viewStub.Object, flightServiceStub.Object, locationServiceMock.Object, airportServicStub.Object);
            viewStub.Setup(x => x.Model).Returns(new SearchFlightViewModel());

            // Act
            presenter.View_InitCountries(It.IsAny<object>(), It.IsAny<EventArgs>());

            // Assert
            locationServiceMock.Verify(x => x.GetAllCountries(), Times.Once);
        }
    }
}
