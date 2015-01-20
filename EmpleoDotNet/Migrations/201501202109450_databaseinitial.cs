namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseinitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOpportunities",
                c => new
                    {
                        JobOpportunityId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        CompanyUrl = c.String(),
                        CompanyEmail = c.String(nullable: false),
                        CompanyLogoUrl = c.String(),
                        PublishedDate = c.DateTime(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JobOpportunityId)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOpportunities", "LocationId", "dbo.Locations");
            DropIndex("dbo.JobOpportunities", new[] { "LocationId" });
            DropTable("dbo.Locations");
            DropTable("dbo.JobOpportunities");
        }
    }
}
