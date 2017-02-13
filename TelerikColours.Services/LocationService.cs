using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using TelerikColours.Services.Contracts;
using TelerikColours.Services.Contracts.Factories;

namespace TelerikColours.Services
{
    public class LocationService : ILocationService
    {
        private IRepository<Country> countryRepositry;
        private IRepository<City> cityRepository;
        //private IUnitOfWork unitOfWork;

        public LocationService(IRepository<Country> countryRepositry, IRepository<City> cityRepository)
        {
            if (countryRepositry == null)
            {
                throw new NullReferenceException("CountryRepository");
            }

            if (cityRepository == null)
            {
                throw new NullReferenceException("CityRepository");
            }

            //if (unitOfWork == null)
            //{
            //    throw new NullReferenceException("UnitOfWork is null");
            //}

            this.countryRepositry = countryRepositry;
            this.cityRepository = cityRepository;
          //  this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return this.countryRepositry.GetAll();
        }

        public IEnumerable<City> GetCityInCountry(int countryId)
        {
            
           // var cities = this.cityRepository.GetAll(x => x.CountryId == countryId, x => x.Name);
            var cities = this.cityRepository.GetAll(x => x.CountryId == countryId);

            return cities;
        }

        public IEnumerable<City> GetAllCities()
        {
            return this.cityRepository.GetAll();
        }
    }
}
