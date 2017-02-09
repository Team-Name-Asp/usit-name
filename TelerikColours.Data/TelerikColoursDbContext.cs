using Models;
using System;
using System.Data.Entity;

namespace TelerikColours.Data
{
    public class TelerikColoursDbContext : DbContext
    {
        public TelerikColoursDbContext()
            : base("TelerikColoursDatabase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TelerikColoursDbContext>());

        }

        public virtual DbSet<Airport> Airports { get; set; }

        public virtual DbSet<Airline> Airlines { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Flight> Flights { get; set; }

        public new void SaveChanges()
        {
            try
            {
                base.SaveChanges();

            }
            catch (Exception e)
            {

                throw;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Airport>()
            //    .HasMany(x => x.Arrival)
            //    .WithRequired(x => x.AirportArrival)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Airport>()
            //   .HasMany(x => x.Arrival)
            //   .WithRequired(x => x.AirportDeparture)
            //   .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
