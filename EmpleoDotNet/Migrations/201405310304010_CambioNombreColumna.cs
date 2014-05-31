namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioNombreColumna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "Title", c => c.String());
            DropColumn("dbo.JobOpportunities", "JobTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOpportunities", "JobTitle", c => c.String());
            DropColumn("dbo.JobOpportunities", "Title");
        }
    }
}
