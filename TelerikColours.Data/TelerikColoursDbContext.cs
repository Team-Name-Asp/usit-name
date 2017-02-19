using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Data.Entity;
using TelerikColours.Data.Contracts;

namespace TelerikColours.Data
{
    public class TelerikColoursDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public TelerikColoursDbContext()
            : base("TelerikColoursDatabase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TelerikColoursDbContext>());
        }

        ///  public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<Airport> Airports { get; set; }

        public virtual DbSet<Airline> Airlines { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Flight> Flights { get; set; }

        public virtual DbSet<Job> Jobs { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public static TelerikColoursDbContext Create()
        {
            return new TelerikColoursDbContext();
        }

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

            modelBuilder.Entity<Airport>()
                .HasMany(x => x.Arrival)
                .WithRequired(x => x.AirportArrival)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
               .HasMany(x => x.Arrival)
               .WithRequired(x => x.AirportDeparture)
               .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
