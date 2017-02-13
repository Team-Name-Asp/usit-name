namespace TelerikColours.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airlines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                        Airline_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Airlines", t => t.Airline_Id)
                .Index(t => t.CountryId)
                .Index(t => t.Airline_Id);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailableSeats = c.Int(nullable: false),
                        DateOfDeparture = c.DateTime(nullable: false),
                        DateOfArrival = c.DateTime(nullable: false),
                        AirlineId = c.Int(nullable: false),
                        AirportDepartureId = c.Int(nullable: false),
                        AirportArrivalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airlines", t => t.AirlineId, cascadeDelete: true)
                .ForeignKey("dbo.Airports", t => t.AirportArrivalId, cascadeDelete: true)
                .ForeignKey("dbo.Airports", t => t.AirportDepartureId)
                .Index(t => t.AirlineId)
                .Index(t => t.AirportDepartureId)
                .Index(t => t.AirportArrivalId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobDescription = c.String(),
                        Slots = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Wage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyName = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "Airline_Id", "dbo.Airlines");
            DropForeignKey("dbo.Jobs", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Airports", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Flights", "AirportDepartureId", "dbo.Airports");
            DropForeignKey("dbo.Flights", "AirportArrivalId", "dbo.Airports");
            DropForeignKey("dbo.Flights", "AirlineId", "dbo.Airlines");
            DropIndex("dbo.Jobs", new[] { "CityId" });
            DropIndex("dbo.Flights", new[] { "AirportArrivalId" });
            DropIndex("dbo.Flights", new[] { "AirportDepartureId" });
            DropIndex("dbo.Flights", new[] { "AirlineId" });
            DropIndex("dbo.Airports", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "Airline_Id" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropTable("dbo.Jobs");
            DropTable("dbo.Countries");
            DropTable("dbo.Flights");
            DropTable("dbo.Airports");
            DropTable("dbo.Cities");
            DropTable("dbo.Airlines");
        }
    }
}
