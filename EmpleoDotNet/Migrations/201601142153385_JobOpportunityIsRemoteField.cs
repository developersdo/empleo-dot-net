namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOpportunityIsRemoteField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "IsRemote", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "IsRemote");
        }
    }
}
