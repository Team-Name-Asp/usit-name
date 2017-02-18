﻿using Models;
using Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using TelerikColours.Services.Contracts;
using TelerikColours.Services.Contracts.Factories;
using TelerikColours.Services.Models;
using TelerikColours.Services.Utils;

namespace TelerikColours.Services
{
    public class UserService : IUserService
    {
        private IRepository<ApplicationUser> userRepository;
        private IRepository<Flight> flightRepository;
        private IUnitOfWork unitOfWork;
        private IAirportFactory airportFactory;
        private IRepository<Ticket> ticketRepository;

        public UserService(IRepository<ApplicationUser> userRepository, IRepository<Flight> flightRepository, IUnitOfWork unitOfWork, IAirportFactory airportFactory, IRepository<Ticket> ticketRepository)
        {
            if (userRepository == null)
            {
                throw new NullReferenceException("UserRepository");
            }

            if (flightRepository == null)
            {
                throw new NullReferenceException("FlightRepository");
            }

            if (unitOfWork == null)
            {
                throw new NullReferenceException("UnitOfWork");
            }

            if (airportFactory == null)
            {
                throw new NullReferenceException("AirportFactory");
            }

            if (ticketRepository == null)
            {
                throw new NullReferenceException("TicketRepository");
            }

            this.userRepository = userRepository;
            this.flightRepository = flightRepository;
            this.unitOfWork = unitOfWork;
            this.airportFactory = airportFactory;
            this.ticketRepository = ticketRepository;
        }

        public bool BuyTicket(string userId, IEnumerable<PresentationFlight> flights)
        {
            var user = userRepository.GetById(userId);

            if (user.Money < flights.Sum(f => f.Price))
            {
                return false;
            }

            using (this.unitOfWork)
            {
                foreach (var flight in flights)
                {
                    var ticket = this.airportFactory.CreateTicket(flight.Id, userId, TimeProvider.Current.GetDate());
                    user.Money -= flight.Price;

                    var flightToReduceSeat = this.flightRepository.GetById(flight.Id);
                    flightToReduceSeat.AvailableSeats -= 1;

                    this.ticketRepository.Add(ticket);
                    this.flightRepository.Update(flightToReduceSeat);
                }

                this.userRepository.Update(user);

                this.unitOfWork.Commit();
            }

            return true;
        }
    }
}