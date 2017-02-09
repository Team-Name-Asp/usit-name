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
        private IUnitOfWork unitOfWork;
        private ILocationFactory locationFactory;
        private IAirportFactory airportFactory;
        private IJobFactory jobFactory;

        public FactoryService(IRepository<Country> countryRepositry, IRepository<City> cityRepository,
              IRepository<Flight> flightRepository, IRepository<Airport> airportRepository, IRepository<Airline> airlineRepository, IUnitOfWork unitOfWork, IAirportFactory airportFactory, ILocationFactory locationFactory)
        {
            if (countryRepositry == null)
            {
                throw new NullReferenceException("CountryRepository");
            }

            if (cityRepository == null)
            {
                throw new NullReferenceException("CityRepository");
            }

            if(flightRepository == null)
            {
                throw new NullReferenceException("FlightRepository");
            }

            if(airportRepository == null)
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

            if(airportFactory == null)
            {
                throw new NullReferenceException("AirportFactory");
            }

            if(locationFactory == null)
            {
                throw new NullReferenceException("LocationFactory");
            }

            this.countryRepositry = countryRepositry;
            this.cityRepository = cityRepository;
            this.airportRepository = airportRepository;
            this.unitOfWork = unitOfWork;
            this.flightRepository = flightRepository;
            this.locationFactory = locationFactory;
            this.airportFactory = airportFactory;
            this.airlineRepository = airlineRepository;
        }

        public void AddCountry(string country)
        {
            using (this.unitOfWork)
            {
                Country newCountry = this.locationFactory.CreateCountry();
                newCountry.Name = country;

                this.countryRepositry.Add(newCountry);

                this.unitOfWork.Commit();
            }
        }

        public void AddCity(int countryId, string city)
        {
            using (this.unitOfWork)
            {
                City newCity = this.locationFactory.CreateCity();
                newCity.Name = city;

                //Country country = this.countryRepositry.GetById(countryId);
                newCity.CountryId = countryId;

                this.cityRepository.Add(newCity);

                this.unitOfWork.Commit();
            }
        }

        public void AddAirport(int cityId, string name)
        {
            Airport airport = this.airportFactory.CreateAirport();

            airport.CityId = cityId;
            airport.Name = name;

            this.airportRepository.Add(airport);

            this.unitOfWork.Commit();
        }

        public void AddFlight(int airportArrivalId, int airportDepartureId, DateTime departureDate, DateTime arrivalDate, decimal price, int airlineId)
        {
            Flight flight = this.airportFactory.CreateFlight();

            flight.AirlineId = airlineId;
            flight.AirportArrivalId = airportArrivalId;
            flight.AirportDepartureId = airportDepartureId;
            flight.DateOfArrival = arrivalDate;
            flight.DateOfDeparture = departureDate;
            flight.Price = price;

            using (this.unitOfWork)
            {
                this.flightRepository.Add(flight);

                var airline = this.airlineRepository.GetById(airlineId);
                airline.Flights.Add(flight);

                var departureAirport = this.airportRepository.GetById(airportDepartureId);
                departureAirport.Departure.Add(flight);

                var arrivalAirport = this.airportRepository.GetById(airportArrivalId);
                arrivalAirport.Arrival.Add(flight);

                airline.Cities.Add(departureAirport.City);
                airline.Cities.Add(arrivalAirport.City);

                this.unitOfWork.Commit();
            }
        }

        public void AddAirline(string name)
        {
            Airline airline = this.airportFactory.CreateAirline();
            airline.Name = name;

            using (this.unitOfWork)
            {
                this.airlineRepository.Add(airline);

                this.unitOfWork.Commit();
            }
        }

        public void AddJob(string jobTitle, string jobDescription, int slots, string description, DateTime startDate, DateTime endDate, decimal wage, string companyName, int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
