using Models;
using Moq;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using TelerikColours.Services;
using TelerikColours.Services.Contracts.Factories;
using TelerikColours.Services.Models;
using TelerikColours.Services.Utils;

namespace TelerikColours.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class BuyTicket_Should
    {
        [TestCase("asddsasdasd202dsa")]
        [TestCase("iaosdjdas8ads")]

        public void CallGetByIdOfUserRepository_WithProvidedId(string userId)
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var userService = new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkStub.Object, airportFactoryStub.Object, ticketRepositoryStub.Object);

            var appUser = new ApplicationUser();

            userRepositoryStub.Setup(x => x.GetById(It.IsAny<string>())).Returns(appUser);
            // Act
            userService.BuyTicket(userId, new List<PresentationFlight>());

            // Assert
            userRepositoryStub.Verify(x => x.GetById(It.Is<string>(id => id == userId)), Times.Once);
        }

        [TestCase(20, 30, 45)]
        [TestCase(23, 555, 555)]

        public void ReturnFalse_WhenUserMoneyAreLessThanFlightCollectionPrice(decimal firstFlightPrice, decimal secondFlightPrice, decimal userMoney)
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var userService = new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkStub.Object, airportFactoryStub.Object, ticketRepositoryStub.Object);

            var presentationFlights = new List<PresentationFlight>()
            {
                new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), firstFlightPrice, It.IsAny<string>()),
                 new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), secondFlightPrice, It.IsAny<string>())
            };

            var appUser = new ApplicationUser();

            appUser.Money = userMoney;

            userRepositoryStub.Setup(x => x.GetById(It.IsAny<string>())).Returns(appUser);

            // Act
            var actualResult = userService.BuyTicket(It.IsAny<string>(), presentationFlights);

            // Assert
            Assert.AreEqual(false, actualResult);
        }

        [TestCase(20, 30, 425)]
        [TestCase(23, 555, 5505)]
        public void CallUnitOfWorkOnce_WhenUserHaveEnoughMoney(decimal firstFlightPrice, decimal secondFlightPrice, decimal userMoney)
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var userService = new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkMock.Object, airportFactoryStub.Object, ticketRepositoryStub.Object);

            var presentationFlights = new List<PresentationFlight>()
            {
                new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), firstFlightPrice, It.IsAny<string>()),
                 new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), secondFlightPrice, It.IsAny<string>())
            };

            var mockedFlight = new Mock<Flight>();
            flightRepositoryStub.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedFlight.Object);

            var appUser = new ApplicationUser();

            appUser.Money = userMoney;

            userRepositoryStub.Setup(x => x.GetById(It.IsAny<string>())).Returns(appUser);

            // Act
           userService.BuyTicket(It.IsAny<string>(), presentationFlights);

            // Assert
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }

        [TestCase(20, 30, 425, 1, "dsaodsa2")]
        [TestCase(23, 555, 5505, 2, "asd22asd")]
        public void CallCreateTicketOnAirportFactoryWithExpectedParameters_WhenUserHaveEnoughMoney(decimal firstFlightPrice, decimal secondFlightPrice, decimal userMoney, int flightId, string userId)
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryMock = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var userService = new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkStub.Object, airportFactoryMock.Object, ticketRepositoryStub.Object);

           
            var presentationFlights = new List<PresentationFlight>()
            {
                new PresentationFlight(flightId, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), firstFlightPrice, It.IsAny<string>()),
                 new PresentationFlight(flightId, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), secondFlightPrice, It.IsAny<string>())
            };

            var appUser = new ApplicationUser();
            appUser.Money = userMoney;
            userRepositoryStub.Setup(x => x.GetById(It.IsAny<string>())).Returns(appUser);

            var mockedDate = new DateTime(2017, 10, 10);
            var timeProvider = new Mock<TimeProvider>();

            timeProvider.Setup(x => x.GetDate()).Returns(mockedDate);
            TimeProvider.Current = timeProvider.Object;

            var mockedFlight = new Mock<Flight>();
            flightRepositoryStub.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedFlight.Object);

            // Act
            userService.BuyTicket(userId, presentationFlights);

            // Assert
            airportFactoryMock.Verify(x => x.CreateTicket(It.Is<int>(fId => fId == flightId), It.Is<string>(uId => uId == userId), It.Is<DateTime>(date => date == mockedDate)), Times.Exactly(2));

            TimeProvider.ResetToDefault();
        }


        [TestCase(20, 30, 425)]
        [TestCase(23, 555, 5505)]
        public void ReduceUserMoney_WithComulatedPriceOfFlights_WhenUserHaveEnoughMoney(decimal firstFlightPrice, decimal secondFlightPrice, decimal userMoney)
        {
            // Arrange
            var flightRepositoryStub = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryStub = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var userService = new UserService(userRepositoryStub.Object, flightRepositoryStub.Object, unitOfWorkStub.Object, airportFactoryStub.Object, ticketRepositoryStub.Object);

            var presentationFlights = new List<PresentationFlight>()
            {
                new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), firstFlightPrice, It.IsAny<string>()),
                 new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), secondFlightPrice, It.IsAny<string>())
            };

            var mockedFlight = new Mock<Flight>();
            flightRepositoryStub.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedFlight.Object);

            var appUser = new ApplicationUser();
            appUser.Money = userMoney;
            userRepositoryStub.Setup(x => x.GetById(It.IsAny<string>())).Returns(appUser);

            var expectedMoney = (userMoney - firstFlightPrice - secondFlightPrice);


            // Act
            userService.BuyTicket(It.IsAny<string>(), presentationFlights);

            // Assert

            Assert.AreEqual(expectedMoney, appUser.Money);
        }

        [TestCase(20, 30, 425, 1)]
        [TestCase(23, 555, 5505, 2)]
        public void CallGetById_OnFlightRepositoryWithExpectedParameters_WhenUserHaveEnoughMoney(decimal firstFlightPrice, decimal secondFlightPrice, decimal userMoney, int flightId)
        {
            // Arrange
            var flightRepositoryMock = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryMock = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var userService = new UserService(userRepositoryStub.Object, flightRepositoryMock.Object, unitOfWorkStub.Object, airportFactoryMock.Object, ticketRepositoryStub.Object);


            var presentationFlights = new List<PresentationFlight>()
            {
                new PresentationFlight(flightId, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), firstFlightPrice, It.IsAny<string>()),
                 new PresentationFlight(flightId, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), secondFlightPrice, It.IsAny<string>())
            };

            var appUser = new ApplicationUser();
            appUser.Money = userMoney;
            userRepositoryStub.Setup(x => x.GetById(It.IsAny<string>())).Returns(appUser);

            var mockedFlight = new Mock<Flight>();
            flightRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedFlight.Object);

            // Act
            userService.BuyTicket(It.IsAny<string>(), presentationFlights);

            // Assert

            flightRepositoryMock.Verify(x => x.GetById(It.Is<int>(fId => fId == flightId)), Times.Exactly(2));
        }

        [TestCase(20, 30, 425, 21)]
        [TestCase(23, 555, 5505, 2)]
        public void ReduceMockedFlightAvailableSeatsWithTwo_WhenUserHaveEnoughMoney(decimal firstFlightPrice, decimal secondFlightPrice, decimal userMoney, int availableSeats)
        {
            // Arrange
            var flightRepositoryMock = new Mock<IRepository<Flight>>();
            var userRepositoryStub = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var airportFactoryMock = new Mock<IAirportFactory>();
            var ticketRepositoryStub = new Mock<IRepository<Ticket>>();
            var userService = new UserService(userRepositoryStub.Object, flightRepositoryMock.Object, unitOfWorkStub.Object, airportFactoryMock.Object, ticketRepositoryStub.Object);


            var presentationFlights = new List<PresentationFlight>()
            {
                new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), firstFlightPrice, It.IsAny<string>()),
                 new PresentationFlight(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>(),  It.IsAny<DateTime>(), It.IsAny<DateTime>(), secondFlightPrice, It.IsAny<string>())
            };

            var appUser = new ApplicationUser();
            appUser.Money = userMoney;
            userRepositoryStub.Setup(x => x.GetById(It.IsAny<string>())).Returns(appUser);


            var mockedFlight = new Mock<Flight>();
            mockedFlight.Object.AvailableSeats = availableSeats;

            flightRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedFlight.Object);

            // Act
            userService.BuyTicket(It.IsAny<string>(), presentationFlights);

            // Assert
            Assert.AreEqual(availableSeats - 2, mockedFlight.Object.AvailableSeats);
        }
    }
}

//public bool BuyTicket(string userId, IEnumerable<PresentationFlight> flights)
//{
//    var user = userRepository.GetById(userId);

//    if (user.Money < flights.Sum(f => f.Price))
//    {
//        return false;
//    }

//    using (this.unitOfWork)
//    {
//        foreach (var flight in flights)
//        {
//            var ticket = this.airportFactory.CreateTicket(flight.Id, userId, TimeProvider.Current.GetDate());
//            user.Money -= flight.Price;

//            var flightToReduceSeat = this.flightRepository.GetById(flight.Id);
//            flightToReduceSeat.AvailableSeats -= 1;

//            this.ticketRepository.Add(ticket);
//            this.flightRepository.Update(flightToReduceSeat);
//        }

//        this.userRepository.Update(user);

//        this.unitOfWork.Commit();
//    }

//    return true;
//}
//    }