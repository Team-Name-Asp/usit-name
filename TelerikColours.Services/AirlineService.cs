using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IRepository<Airline> airlineRepository;

        public AirlineService(IRepository<Airline> airlineRepository)
        {
            if (airlineRepository == null)
            {
                throw new NullReferenceException("AirlineRepository");
            }

            this.airlineRepository = airlineRepository;
        }

        public IEnumerable<Airline> GetAllAirlines()
        {
            return this.airlineRepository.GetAll();
        }
    }
}
