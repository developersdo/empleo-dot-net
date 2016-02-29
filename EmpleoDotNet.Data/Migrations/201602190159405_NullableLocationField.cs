namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableLocationField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobOpportunities", "LocationId", "dbo.Locations");
            DropIndex("dbo.JobOpportunities", new[] { "LocationId" });
            AlterColumn("dbo.JobOpportunities", "LocationId", c => c.Int());
            CreateIndex("dbo.JobOpportunities", "LocationId");
            AddForeignKey("dbo.JobOpportunities", "LocationId", "dbo.Locations", "LocationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOpportunities", "LocationId", "dbo.Locations");
            DropIndex("dbo.JobOpportunities", new[] { "LocationId" });
            AlterColumn("dbo.JobOpportunities", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobOpportunities", "LocationId");
            AddForeignKey("dbo.JobOpportunities", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
        }
    }
}
