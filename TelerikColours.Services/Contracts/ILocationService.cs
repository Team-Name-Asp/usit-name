using Models;
using System.Collections.Generic;

namespace TelerikColours.Services.Contracts
{
    public interface ILocationService
    {
        IEnumerable<Country> GetAllCountries();

        IEnumerable<City> GetCityInCountry(int countryId);
    }
}
