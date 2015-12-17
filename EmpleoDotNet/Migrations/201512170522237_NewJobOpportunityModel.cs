namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewJobOpportunityModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobOpportunities", "CompanyName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Locations", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Name", c => c.String());
            AlterColumn("dbo.JobOpportunities", "CompanyName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
