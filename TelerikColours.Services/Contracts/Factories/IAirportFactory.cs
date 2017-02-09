using Models;

namespace TelerikColours.Services.Contracts.Factories
{
    public interface IAirportFactory
    {
        Airport CreateAirport();

        Flight CreateFlight();

        Airline CreateAirline();
    }
}
