namespace TelerikColours.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<TelerikColours.Data.TelerikColoursDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TelerikColours.Data.TelerikColoursDbContext context)
        {
            var bulgaria = new Country() { Name = "Bulgaria" };
            var germany = new Country() { Name = "Germany" };
            var ireland = new Country() { Name = "Ireland" };


            context.Countries.Add(bulgaria);
            context.Countries.Add(germany);
            context.Countries.Add(ireland);

            var city = new City() { Name = "Sofia" };
            city.Country = bulgaria;

            var plovdiv = new City() { Name = "Plovdiv" };
            plovdiv.Country = bulgaria;

            var berlin = new City() { Name = "Berlin" };
            berlin.Country = germany;

            context.Cities.Add(city);
            context.Cities.Add(plovdiv);
            context.Cities.Add(berlin);


            var firstAirport = new Airport() { Name = "Sofia Airport" };
            firstAirport.City = city;

            var secondAirport = new Airport() { Name = "Second Airport" };
            secondAirport.City = plovdiv;

            var thirdAirport = new Airport() { Name = "Berlin Airport" };
            thirdAirport.City = berlin;

            context.Airports.Add(firstAirport);
            context.Airports.Add(secondAirport);
            context.Airports.Add(thirdAirport);


            var bgAir = new Airline() { Name = "BgAir" };
            bgAir.Cities.Add(city);
            bgAir.Cities.Add(plovdiv);
            bgAir.Cities.Add(berlin);

            context.Airlines.Add(bgAir);

            var newDate = DateTime.UtcNow;
            newDate.AddHours(3);

            var firstFlight = new Flight() { DateOfDeparture = DateTime.UtcNow, DateOfArrival = newDate, Price = 30 };
            firstFlight.Airline = bgAir;
            firstFlight.AirportDeparture = firstAirport;
            firstFlight.AirportArrival = thirdAirport;


            bgAir.Flights.Add(firstFlight);


            context.Flights.Add(firstFlight);

            firstAirport.Departure.Add(firstFlight);
            thirdAirport.Arrival.Add(firstFlight);


            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
