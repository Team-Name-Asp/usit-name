//using Models;
//using Moq;
//using NUnit.Framework;
//using Repositories.Contracts;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using TelerikColours.Services;
//using TelerikColours.Services.Contracts.Factories;

//namespace TelerikColours.Tests.Services.FlightServiceTests
//{
//    [TestFixture]
//    public class GetFlights_Should
//    {
//        [Test]
//        public void Set()
//        {
//            // Arrange
//            var flightRepositoryStub = new Mock<IRepository<Flight>>();
//            var airportRepositoryStub = new Mock<IRepository<Airport>>();
//            var cityRepositoryStub = new Mock<IRepository<City>>();
//            var mappedFactory = new Mock<IMappedClassFactory>();
//            var unitOfWorkStub = new Mock<IUnitOfWork>();
//            var flightService = new FlightService(airportRepositoryStub.Object, unitOfWorkStub.Object, flightRepositoryStub.Object, cityRepositoryStub.Object, mappedFactory.Object);

//            var travenDate = new DateTime(2017, 10, 10);
//            // Airport setup
//            airportRepositoryStub.Setup(a => a.GetAll()).Returns()
//        }

//        private IEnumerable<Airport> GetAirports()
//        {
//            var sofiaAirport = new Airport() { Id = 1, Name = "Sofia" };
//            var berlinAirport = new Airport() { Id = 2, Name = "Berlin" };

//            var erfurtAirport = new Airport() { Id = 3, Name = "Erfurt" };
//            var burgasAirport = new Airport() { Id = 4, Name = "Burgas" };
//            var dublinAirport = new Airport() { Id = 5, Name = "Dublin" };
//            var varnaAirport = new Airport() { Id = 6, Name = "Varna" };


//        }
//    }
//}

