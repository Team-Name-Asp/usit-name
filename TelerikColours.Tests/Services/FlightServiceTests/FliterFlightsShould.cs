using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Tests.Services.FlightServiceTests
{
    [TestFixture]
    public class FliterFlightsShould
    {
        [Test]
        public void Call()
        {
            // Arrange
            var airportRepositoryStub = new Mock<IRepository<Airport>>();
            var flightRepositoryMock = new Mock<IRepository<Flight>>();
            var cityRepositoryStub = new Mock<IRepository<City>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mappedFactory = new Mock<IMappedClassFactory>();
            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkMock.Object, flightRepositoryMock.Object, cityRepositoryStub.Object, mappedFactory.Object);

            // Act

        }
    }
}
//public IEnumerable<Flight> FilterFlights(string type, string filterExpression)
//{
//    IQueryable<Flight> resultQuery = null;
//    if (type == "date")
//    {
//        var queryDate = DateTime.Parse(filterExpression);
//        resultQuery = this.flightRepository.All.Where(x => x.DateOfDeparture.DayOfYear == queryDate.DayOfYear);
//    }
//    else if (type == "airline")
//    {
//        resultQuery = this.flightRepository.All.Include(x => x.Airline).Where(x => x.Airline.Name == filterExpression);
//    }
//    else if (type == "airport")
//    {
//        resultQuery = this.flightRepository.All.Include(x => x.AirportArrival).Include(x => x.AirportDeparture).Where(x => x.AirportDeparture.Name == filterExpression || x.AirportArrival.Name == filterExpression);
//    }

//    return resultQuery.ToList();
//}