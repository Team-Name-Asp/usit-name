﻿using System;

namespace TelerikColours.Services.Contracts
{
    public interface IFactoryService
    {
        void AddCountry(string country);

        void AddCity(int countryId, string city);

        void AddAirport(int cityId, string name);

        void AddFlight(int airportArrivalId, int airportDepartureId, DateTime departureDate, DateTime arrivalDate, decimal price, int airlineId);

        void AddAirline(string name);

        void AddJob(string jobTitle, string jobDescription, int slots, DateTime startDate, DateTime endDate, decimal wage, string companyName, int cityId);
    }
}

