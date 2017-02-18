using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FlightServiceTests
{
    [TestFixture]
    public class FliterFlightsShould
    {
        [Test]
        public void ReturnSameColelction_WhenFilteredWithSameExpressionsForTypeDate()
        {
            // Arrange
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var flightRepositoryMock = new Mock<IRepository<Flight>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkMock.Object, flightRepositoryMock.Object, cityRepositoryStub.Object, mappedFactory.Object);

            var dateOfDeparture = new DateTime(2016, 4, 1, 10, 10, 10);
            var secondDateOfDeparture = new DateTime(2016, 4, 1, 12, 10, 10);
            var differentDayDate = new DateTime(2016, 4, 2, 12, 10, 10);

            var flights = new List<Flight>()
            {
                new Flight(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>() ,secondDateOfDeparture, It.IsAny<decimal>(), It.IsAny<int>()),
                new Flight(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>() ,differentDayDate, It.IsAny<decimal>(), It.IsAny<int>()),
                new Flight(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>() ,dateOfDeparture, It.IsAny<decimal>(), It.IsAny<int>())
            }.AsQueryable();


            flightRepositoryMock.Setup(f => f.All).Returns(flights);

            string sortType = "date";
            string filterExpression = dateOfDeparture.ToString();

            var expectedFlights = flights.Where(x => x.DateOfDeparture.DayOfYear == dateOfDeparture.DayOfYear).OrderBy(x => x.DateOfDeparture);

            // Act
            var actualFlights = flightService.FilterFlights(sortType, filterExpression);

            // Assert
            CollectionAssert.AreEqual(expectedFlights, actualFlights);
        }

        [TestCase("FirstAirline")]
        [TestCase("SecondAirline")]
        public void ReturnSameColelction_WhenFilteredWithSameExpressionsForAirline(string airlineName)
        {
            // Arrange
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var flightRepositoryMock = new Mock<IRepository<Flight>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkMock.Object, flightRepositoryMock.Object, cityRepositoryStub.Object, mappedFactory.Object);

            var dateOfDeparture = new DateTime(2016, 4, 1, 10, 10, 10);
            var secondDateOfDeparture = new DateTime(2016, 4, 1, 12, 10, 10);
            var differentDayDate = new DateTime(2016, 4, 2, 12, 10, 10);

            var flights = new List<Flight>()
            {
                new Flight()
                {
                    Airline = new Airline()
                    {
                        Name = airlineName
                    },
                    DateOfDeparture = differentDayDate
                },
                 new Flight()
                {
                    Airline = new Airline()
                    {
                        Name = "Different"
                    },
                    DateOfDeparture = secondDateOfDeparture
                },
                  new Flight()
                {
                    Airline = new Airline()
                    {
                        Name = airlineName
                    },
                    DateOfDeparture = dateOfDeparture
                },
            }.AsQueryable();


            flightRepositoryMock.Setup(f => f.All).Returns(flights);

            string sortType = "airline";
            string filterExpression = airlineName;

            var expectedFlights = flights.Include(x => x.Airline).Where(x => x.Airline.Name == filterExpression).OrderBy(x => x.DateOfDeparture);

            // Act
            var actualFlights = flightService.FilterFlights(sortType, filterExpression);

            // Assert
            CollectionAssert.AreEqual(expectedFlights, actualFlights);
        }

        [TestCase("FirstAirport")]
        [TestCase("SecondAirport")]
        public void ReturnSameColelction_WhenFilteredWithSameExpressionsForAirport(string airportName)
        {
            // Arrange
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var flightRepositoryMock = new Mock<IRepository<Flight>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkMock.Object, flightRepositoryMock.Object, cityRepositoryStub.Object, mappedFactory.Object);

            var dateOfDeparture = new DateTime(2016, 4, 1, 10, 10, 10);
            var secondDateOfDeparture = new DateTime(2016, 4, 1, 12, 10, 10);
            var differentDayDate = new DateTime(2016, 4, 2, 12, 10, 10);

            var flights = new List<Flight>()
            {
                new Flight()
                {
                    AirportArrival = new Airport()
                    {
                        Name = airportName
                    },
                    DateOfDeparture = differentDayDate,
                    AirportDeparture = new Airport()
                   
                },
                 new Flight()
                {
                    AirportArrival = new Airport()
                    {
                        Name = "Different"
                    },
                    DateOfDeparture = secondDateOfDeparture,
                    AirportDeparture = new Airport()
                    {
                        Name = airportName
                    },
                },
                  new Flight()
                {
                    AirportArrival = new Airport()
                    {
                        Name = airportName
                    },
                    DateOfDeparture = dateOfDeparture,
                    AirportDeparture = new Airport()
                },
                  new Flight()
                {
                    AirportArrival = new Airport()
                    {
                        Name = "Different"
                    },
                    DateOfDeparture = secondDateOfDeparture,
                    AirportDeparture = new Airport()
                },

            }.AsQueryable();


            flightRepositoryMock.Setup(f => f.All).Returns(flights);

            string sortType = "airport";
            string filterExpression = airportName;

            var expectedFlights = flights.Include(x => x.AirportArrival).Include(x => x.AirportDeparture).Where(x => x.AirportDeparture.Name == filterExpression || x.AirportArrival.Name == filterExpression).OrderBy(x => x.DateOfDeparture);

            // Act
            var actualFlights = flightService.FilterFlights(sortType, filterExpression);

            // Assert
            CollectionAssert.AreEqual(expectedFlights, actualFlights);
        }
    }
}
