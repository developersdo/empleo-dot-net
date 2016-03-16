namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHowApplyField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "HowApply", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "HowApply");
        }
    }
}
