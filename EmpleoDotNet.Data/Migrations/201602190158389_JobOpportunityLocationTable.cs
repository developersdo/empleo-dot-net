namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOpportunityLocationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOpportunityLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceId = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        Latitude = c.String(nullable: false),
                        Longitude = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.JobOpportunities", "JobOpportunityLocationId", c => c.Int());
            CreateIndex("dbo.JobOpportunities", "JobOpportunityLocationId");
            AddForeignKey("dbo.JobOpportunities", "JobOpportunityLocationId", "dbo.JobOpportunityLocations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOpportunities", "JobOpportunityLocationId", "dbo.JobOpportunityLocations");
            DropIndex("dbo.JobOpportunities", new[] { "JobOpportunityLocationId" });
            DropColumn("dbo.JobOpportunities", "JobOpportunityLocationId");
            DropTable("dbo.JobOpportunityLocations");
        }
    }
}
