using Models;
using Repositories.Contracts;
using System;
using TelerikColours.Services.Contracts;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Services
{
    public class FactoryService : IFactoryService
    {
        private IRepository<Country> countryRepositry;
        private IRepository<Flight> flightRepository;
        private IRepository<City> cityRepository;
        private IRepository<Airport> airportRepository;
        private IRepository<Airline> airlineRepository;
        private IRepository<Job> jobRepository;
        private IUnitOfWork unitOfWork;
        private ILocationFactory locationFactory;
        private IAirportFactory airportFactory;
        private IJobFactory jobFactory;

        public FactoryService(IRepository<Country> countryRepositry, IRepository<City> cityRepository,
              IRepository<Flight> flightRepository, IRepository<Airport> airportRepository,
              IRepository<Airline> airlineRepository,
              IUnitOfWork unitOfWork, IAirportFactory airportFactory,
              ILocationFactory locationFactory,
              IRepository<Job> jobRepository, IJobFactory jobFactory)
        {
            if (jobRepository == null)
            {
                throw new NullReferenceException("JobRepository");
            }

            if (countryRepositry == null)
            {
                throw new NullReferenceException("CountryRepository");
            }

            if (cityRepository == null)
            {
                throw new NullReferenceException("CityRepository");
            }

            if (flightRepository == null)
            {
                throw new NullReferenceException("FlightRepository");
            }

            if (airportRepository == null)
            {
                throw new NullReferenceException("AirportRepository");
            }

            if (airlineRepository == null)
            {
                throw new NullReferenceException("AirlineRepository");

            }

            if (unitOfWork == null)
            {
                throw new NullReferenceException("UnitOfWorkS");
            }

            if (airportFactory == null)
            {
                throw new NullReferenceException("AirportFactory");
            }

            if (locationFactory == null)
            {
                throw new NullReferenceException("LocationFactory");
            }

            if (jobFactory == null)
            {
                throw new NullReferenceException("JobFactory");
            }

            this.countryRepositry = countryRepositry;
            this.cityRepository = cityRepository;
            this.airportRepository = airportRepository;
            this.unitOfWork = unitOfWork;
            this.flightRepository = flightRepository;
            this.locationFactory = locationFactory;
            this.airportFactory = airportFactory;
            this.airlineRepository = airlineRepository;
            this.jobRepository = jobRepository;
            this.jobFactory = jobFactory;
        }

        public void AddCountry(string country)
        {
            using (this.unitOfWork)
            {
                Country newCountry = this.locationFactory.CreateCountry(country);

                this.countryRepositry.Add(newCountry);

                this.unitOfWork.Commit();
            }
        }

        public void AddCity(int countryId, string city)
        {
            using (this.unitOfWork)
            {
                City newCity = this.locationFactory.CreateCity(city, countryId);

                this.cityRepository.Add(newCity);

                this.unitOfWork.Commit();
            }
        }

        public void AddAirport(int cityId, string name)
        {
            Airport airport = this.airportFactory.CreateAirport(name, cityId);

            this.airportRepository.Add(airport);

            this.unitOfWork.Commit();
        }

        public void AddFlight(int airportArrivalId, int airportDepartureId, DateTime departureDate, DateTime arrivalDate, decimal price, int airlineId, int availableSeats)
        {
            Flight flight = this.airportFactory.CreateFlight(airlineId, airportArrivalId, airportDepartureId, arrivalDate, departureDate, price, availableSeats);

            using (this.unitOfWork)
            {
                this.flightRepository.Add(flight);
                this.unitOfWork.Commit();
            }
        }

        public void AddAirline(string name)
        {
            Airline airline = this.airportFactory.CreateAirline(name);

            using (this.unitOfWork)
            {
                this.airlineRepository.Add(airline);

                this.unitOfWork.Commit();
            }
        }

        public void AddJob(string jobTitle, string jobDescription, int slots, DateTime startDate, DateTime endDate, decimal wage, string companyName, decimal price, int cityId)
        {
            Job job = this.jobFactory.CreateJob(cityId, jobTitle, jobDescription, slots, startDate, endDate, wage, companyName, price);

            using (this.unitOfWork)
            {
                this.jobRepository.Add(job);

                this.unitOfWork.Commit();
            }
        }
    }
}
