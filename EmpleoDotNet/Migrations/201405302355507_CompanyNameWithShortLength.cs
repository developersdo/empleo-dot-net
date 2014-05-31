namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyNameWithShortLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobOpportunities", "CompanyName", c => c.String(maxLength: 50));
            AlterColumn("dbo.JobOpportunities", "PublishedDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobOpportunities", "PublishedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobOpportunities", "CompanyName", c => c.String());
        }
    }
}
