namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiadoRequirementsToApplyADescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "Description", c => c.String());
            DropColumn("dbo.JobOpportunities", "RequirementsToApply");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOpportunities", "RequirementsToApply", c => c.String());
            DropColumn("dbo.JobOpportunities", "Description");
        }
    }
}
