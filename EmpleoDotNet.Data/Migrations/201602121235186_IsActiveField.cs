namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActiveField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "IsActive");
        }
    }
}
