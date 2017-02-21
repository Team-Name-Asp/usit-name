using Models;
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

                    user.Tickets.Add(ticket);

                    this.ticketRepository.Add(ticket);
                    this.flightRepository.Update(flightToReduceSeat);
                }

                this.userRepository.Update(user);

                this.unitOfWork.Commit();
            }

            return true;
        }

        public IEnumerable<Flight> GetFlightHistory(string userId)
        {
            var flights = this.userRepository.All.Where(u => u.Id == userId).SelectMany(p => p.Tickets).Select(t => t.Flight).OrderBy(t => t.DateOfDeparture);

            return flights.ToList();
        }

        public IEnumerable<Flight> GetUpcommingFlights(string userId)
        {
            var currentDate = TimeProvider.Current.GetDate();
            var flights = this.userRepository.All.Where(u => u.Id == userId).SelectMany(p => p.Tickets).Select(t => t.Flight).Where(f => f.DateOfDeparture > currentDate).OrderBy(t => t.DateOfDeparture);

            return flights.ToList();
        }

        public void AttachJobToUser(string userId, Job job)
        {
            var currentUser = this.userRepository.GetById(userId);

            using (this.unitOfWork)
            {
                currentUser.Jobs.Add(job);
                this.unitOfWork.Commit();
            }
        }

        public IEnumerable<Job> GetUpcommingJobs(string userId)
        {
            var currentDate = TimeProvider.Current.GetDate();

            var jobs = this.userRepository.All.Where(u => u.Id == userId).SelectMany(p => p.Jobs).Where(f => f.StartDate > currentDate).OrderBy(t => t.StartDate);


            return jobs.ToList();
        }

        public IEnumerable<Job> GetJobsHistory(string userId)
        {
            var jobs = this.userRepository.All.Where(u => u.Id == userId).SelectMany(p => p.Jobs).OrderBy(t => t.StartDate);

            return jobs.ToList();
        }
    }
}
