using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Services
{
    public class LocationService : ILocationService
    {
        private IRepository<Country> countryRepositry;
        private IRepository<City> cityRepository;

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

            this.countryRepositry = countryRepositry;
            this.cityRepository = cityRepository;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return this.countryRepositry.GetAll();
        }

        public IEnumerable<City> GetCityInCountry(int countryId)
        {
            var cities = this.cityRepository.GetAll(x => x.CountryId == countryId, x => x.Name);

            return cities;
        }

        public IEnumerable<City> GetAllCities()
        {
            return this.cityRepository.GetAll();
        }
    }
}
