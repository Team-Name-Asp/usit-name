namespace TelerikColours.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Description", c => c.String());
        }
    }
}
