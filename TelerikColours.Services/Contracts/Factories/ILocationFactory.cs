using Models;

namespace TelerikColours.Services.Contracts.Factories
{
    public interface ILocationFactory
    {
        Country CreateCountry();

        City CreateCity();
    }
}
