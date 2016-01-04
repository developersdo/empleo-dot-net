namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApprovedFieldNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobOpportunities", "Approved", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobOpportunities", "Approved", c => c.Boolean(nullable: false));
        }
    }
}
