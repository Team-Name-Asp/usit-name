using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.Admin.AddFlight;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddFlightPresenterTests
{
    [TestFixture]
    public class View_InitialLoad_Should
    {
        [Test]
        public void SetCountryFromListWithExpectedCountryColelction_WhenInitialLoadEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceMock = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            var addFlightPresenter = new AddFlightPresenter(viewMock.Object, locationServiceStub.Object, factoryServiceMock.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object);

            var expectedCountries = new List<Country>()
            {
                new Country(It.IsAny<string>()),
                new Country(It.IsAny<string>()),
                new Country(It.IsAny<string>())
            };

            viewMock.Setup(v => v.Model).Returns(new FlightViewModel());

            locationServiceStub.Setup(l => l.GetAllCountries()).Returns(expectedCountries);

            // Act
            viewMock.Raise(v => v.InitialLoad += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEqual(expectedCountries, viewMock.Object.Model.CountryFromList);
        }

        [Test]
        public void SetCountryToListWithExpectedCountryColelction_WhenInitialLoadEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceMock = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            var addFlightPresenter = new AddFlightPresenter(viewMock.Object, locationServiceStub.Object, factoryServiceMock.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object);

            var expectedCountries = new List<Country>()
            {
                new Country(It.IsAny<string>()),
                new Country(It.IsAny<string>()),
                new Country(It.IsAny<string>())
            };

            viewMock.Setup(v => v.Model).Returns(new FlightViewModel());

            locationServiceStub.Setup(l => l.GetAllCountries()).Returns(expectedCountries);

            // Act
            viewMock.Raise(v => v.InitialLoad += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEqual(expectedCountries, viewMock.Object.Model.CountryToList);
        }

        [Test]
        public void CallGetALlCountriesOnLocationService_Once()
        {
            // Arrange
            var viewMock = new Mock<ICreateFlightVliew>();
            var locationServiceMock = new Mock<ILocationService>();
            var factoryServiceMock = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            var addFlightPresenter = new AddFlightPresenter(viewMock.Object, locationServiceMock.Object, factoryServiceMock.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object);

            viewMock.Setup(v => v.Model).Returns(new FlightViewModel());


            // Act
            viewMock.Raise(v => v.InitialLoad += null, EventArgs.Empty);

            // Assert
            locationServiceMock.Verify(l => l.GetAllCountries(), Times.Once);
        }

        [Test]
        public void SetAirlineListWithExpecteAirlineColelction_WhenInitialLoadEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<ICreateFlightVliew>();
            var locationServiceStub = new Mock<ILocationService>();
            var factoryServiceMock = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceStub = new Mock<IAirlineService>();

            var addFlightPresenter = new AddFlightPresenter(viewMock.Object, locationServiceStub.Object, factoryServiceMock.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceStub.Object);

            var expectedAirlines = new List<Airline>()
            {
                new Airline(It.IsAny<string>()),
                new Airline(It.IsAny<string>()),
                new Airline(It.IsAny<string>())

            };

            viewMock.Setup(v => v.Model).Returns(new FlightViewModel());

            airlineServiceStub.Setup(l => l.GetAllAirlines()).Returns(expectedAirlines);

            // Act
            viewMock.Raise(v => v.InitialLoad += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEqual(expectedAirlines, viewMock.Object.Model.AirlineList);
        }

        [Test]
        public void GetAllAirlinesOnAirlineService_Once()
        {
            // Arrange
            var viewMock = new Mock<ICreateFlightVliew>();
            var locationServiceMock = new Mock<ILocationService>();
            var factoryServiceStub = new Mock<IFactoryService>();
            var flightServiceStub = new Mock<IFlightService>();
            var airportServiceStub = new Mock<IAirportService>();
            var airlineServiceMock = new Mock<IAirlineService>();

            var addFlightPresenter = new AddFlightPresenter(viewMock.Object, locationServiceMock.Object, factoryServiceStub.Object, flightServiceStub.Object, airportServiceStub.Object, airlineServiceMock.Object);

            viewMock.Setup(v => v.Model).Returns(new FlightViewModel());


            // Act
            viewMock.Raise(v => v.InitialLoad += null, EventArgs.Empty);

            // Assert
            airlineServiceMock.Verify(l => l.GetAllAirlines(), Times.Once);
        }
    }
}
