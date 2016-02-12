namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActiveColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "IsActive", c => c.Boolean(nullable: false));
            Sql("UPDATE [JobOpportunities] SET [IsActive] = 1", true);
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "IsActive");
        }
    }
}
