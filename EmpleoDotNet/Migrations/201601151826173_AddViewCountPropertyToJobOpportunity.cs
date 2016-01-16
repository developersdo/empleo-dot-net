namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewCountPropertyToJobOpportunity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "ViewCount");
        }
    }
}
