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
    public class GetFlightsShould
    {
        private Mock<IRepository<Airport>> airportRepository;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IRepository<Airline>> airlineRepository;
        private Mock<IRepository<Flight>> flightRepository;
        private Mock<IRepository<City>> cityRepository;
        private Mock<IMappedClassFactory> mappedFactory;
        private FlightService service;

        [SetUp]
        public void Init()
        {
            this.airportRepository = new Mock<IRepository<Airport>>();
            this.unitOfWork = new Mock<IUnitOfWork>();
            this.flightRepository = new Mock<IRepository<Flight>>();
            this.cityRepository = new Mock<IRepository<City>>();
            this.mappedFactory = new Mock<IMappedClassFactory>();

            this.service = new FlightService(this.airportRepository.Object, this.unitOfWork.Object, this.flightRepository.Object, this.cityRepository.Object, this.mappedFactory.Object);
        }

        [Test]
        public void Return()
        {
         

        }
    }
}
