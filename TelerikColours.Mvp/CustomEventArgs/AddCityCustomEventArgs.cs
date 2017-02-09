﻿namespace TelerikColours.CustomEventArgs
{
    public class AddCityCustomEventArgs
    {
        public int CountryId { get; set; }

        public string CityName { get; set; }

        public AddCityCustomEventArgs(int countryId, string cityName)
        {
            this.CountryId = countryId;
            this.CityName = cityName;
        }
    }
}