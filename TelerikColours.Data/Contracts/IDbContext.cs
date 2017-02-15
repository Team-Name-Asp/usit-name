using System.Data.Entity;
using Models;
using System.Data.Entity.Infrastructure;

namespace TelerikColours.Data.Contracts
{
    public interface IDbContext
    {
        DbSet<Airline> Airlines { get; set; }

        DbSet<Airport> Airports { get; set; }

        DbSet<City> Cities { get; set; }

        DbSet<Country> Countries { get; set; }

        DbSet<Flight> Flights { get; set; }

        DbSet<Job> Jobs { get; set; }

        void SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}