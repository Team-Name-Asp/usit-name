﻿using Models;
using System;

namespace TelerikColours.Services.Contracts.Factories
{
    public interface IAirportFactory
    {
        Airport CreateAirport(string name, int cityId);

        Flight CreateFlight(int airlineId, int airportArrivalId, int airportDepartureId, DateTime arrivalDate, DateTime departureDate, decimal price);

        Airline CreateAirline(string name);
    }
}

