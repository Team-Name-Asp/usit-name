using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;
using TelerikColours.Services.Utils;

namespace TelerikColours.Tests.Services.FlightServiceTests
{
    [TestFixture]
    public class GetCheapestFlights_Should
    {
        [Test]
        public void ReturnExpectedCollection_WhenExpectedExpressionsArePerformedOnCollection()
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkStub.Object, flightRepositoryStub.Object, cityRepositoryStub.Object, mappedFactory.Object);

            var mockedDate = new DateTime(2016, 10, 10, 10, 5, 5, 3);
            var timeProvider = new Mock<TimeProvider>();

            timeProvider.Setup(x => x.GetDate()).Returns(mockedDate);
            TimeProvider.Current = timeProvider.Object;

            var dateAfter = new DateTime(2016, 10, 11, 10, 5, 5, 3);
            var secondDateAfter = new DateTime(2016, 10, 12, 10, 5, 5, 3);
            var dateBefore = new DateTime(2016, 5, 12, 10, 5, 5, 3);


            var flights = new List<Flight>()
            {
                new Flight()
                {
                    DateOfDeparture = secondDateAfter,
                    Price = 20
                },
                 new Flight()
                {
                    DateOfDeparture = dateAfter,
                    Price = 1

                },
                  new Flight()
                {
                    DateOfDeparture = dateBefore,
                    Price = 200
                    
                },
            }.AsQueryable();

            flightRepositoryStub.Setup(f => f.All).Returns(flights);

            var take = 10;

            var expectedFlights = flights.Where(x => x.DateOfDeparture > mockedDate && x.AvailableSeats > 0).OrderBy(x => x.Price).Take(take).ToList();

            // Act
            var actualFlights = flightService.GetCheapestFlights();

            // Assert
            CollectionAssert.AreEqual(expectedFlights, actualFlights);
        }
    }
}

