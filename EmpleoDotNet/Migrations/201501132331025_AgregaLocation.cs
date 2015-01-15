namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregaLocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            AddColumn("dbo.JobOpportunities", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobOpportunities", "LocationId");
            AddForeignKey("dbo.JobOpportunities", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
            DropColumn("dbo.JobOpportunities", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOpportunities", "Location", c => c.String(nullable: false));
            DropForeignKey("dbo.JobOpportunities", "LocationId", "dbo.Locations");
            DropIndex("dbo.JobOpportunities", new[] { "LocationId" });
            DropColumn("dbo.JobOpportunities", "LocationId");
            DropTable("dbo.Locations");
        }
    }
}
