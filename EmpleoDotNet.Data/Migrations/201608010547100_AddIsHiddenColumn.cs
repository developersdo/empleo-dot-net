namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsHiddenColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "IsHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "IsHidden");
        }
    }
}
