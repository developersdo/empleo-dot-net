namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApprovedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "Approved", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "Approved");
        }
    }
}
