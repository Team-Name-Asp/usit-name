//using Models;
//using Moq;
//using NUnit.Framework;
//using Repositories.Contracts;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using TelerikColours.Services;
//using TelerikColours.Services.Contracts.Factories;

//namespace TelerikColours.Tests.Services.FlightServiceTests
//{
//    [TestFixture]
//    public class GetFlights_Should
//    {
//        //[Test]
//        //public void CallGetAll_OnAirportRepositoryOnce()
//        //{
//        //    // Arrange
//        //    var flightRepositoryStub = new Mock<IRepository<Flight>>();
//        //    var airportRepositoryMock = new Mock<IRepository<Airport>>();
//        //    var cityRepositoryStub = new Mock<IRepository<City>>();
//        //    var mappedFactory = new Mock<IMappedClassFactory>();
//        //    var unitOfWorkStub = new Mock<IUnitOfWork>();
//        //    var flightService = new FlightService(airportRepositoryMock.Object, unitOfWorkStub.Object, flightRepositoryStub.Object, cityRepositoryStub.Object, mappedFactory.Object);

//        //    // Act
//        //    flightService.GetFlights(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>().AddDays(10), It.IsAny<int>());

//        //    // Assert
//        //    airportRepositoryMock.Verify(a => a.GetAll(), Times.Once);
//        //}

//        [Test]
//        public void CallCreateFlightNodeOnFactoryServiceAsManyTimesAsAirportCollection()
//        {
//            // Arrange
//            var flightRepositoryStub = new Mock<IRepository<Flight>>();
//            var airportRepositoryMock = new Mock<IRepository<Airport>>();
//            var cityRepositoryStub = new Mock<IRepository<City>>();
//            var mappedFactory = new Mock<IMappedClassFactory>();
//            var unitOfWorkStub = new Mock<IUnitOfWork>();
//            var flightService = new FlightService(airportRepositoryMock.Object, unitOfWorkStub.Object, flightRepositoryStub.Object, cityRepositoryStub.Object, mappedFactory.Object);

//            var airports = this.GetAirports().ToList();
//            airportRepositoryMock.Setup(a => a.GetAll()).Returns(airports);

//            // Act
//            flightService.GetFlights(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>().AddDays(10), It.IsAny<int>());

//            // Assert
//            mappedFactory.Verify(f => f.CreateSecondFlightNode(It.IsAny<int>()), Times.Exactly(airports.Count));
//        }

//        private IEnumerable<Airport> GetAirports()
//        {
//            var sofiaAirport = new Airport() { Id = 1, Name = "Sofia" };
//            var berlinAirport = new Airport() { Id = 2, Name = "Berlin" };

//            var erfurtAirport = new Airport() { Id = 3, Name = "Erfurt" };
//            var burgasAirport = new Airport() { Id = 4, Name = "Burgas" };
//            var dublinAirport = new Airport() { Id = 5, Name = "Dublin" };
//            var varnaAirport = new Airport() { Id = 6, Name = "Varna" };

//            var airports = new List<Airport>() { sofiaAirport, berlinAirport, erfurtAirport, burgasAirport, dublinAirport, varnaAirport };

//            return airports;
//        }
//    }
//}

