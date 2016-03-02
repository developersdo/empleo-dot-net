namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJobTypeField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "JobType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "JobType");
        }
    }
}
