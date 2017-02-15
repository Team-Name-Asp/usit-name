using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Services
{
    public class AirportService : IAirportService
    {
        private readonly IRepository<Airport> airportRepository;

        public AirportService(IRepository<Airport> airportRepository)
        {
            if (airportRepository == null)
            {
                throw new NullReferenceException("AirportRepository");
            }

            this.airportRepository = airportRepository;
        }

        public IEnumerable<Airport> GetAllAirportsInCity(int cityId)
        {
            return this.airportRepository.GetAll(x => x.CityId == cityId, x => x.Name);
        }
    }
}

