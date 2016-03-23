namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBenefitsAndRequirementsFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "Requirements", c => c.String(nullable: false));
            AddColumn("dbo.JobOpportunities", "Benefits", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "Benefits");
            DropColumn("dbo.JobOpportunities", "Requirements");
        }
    }
}
