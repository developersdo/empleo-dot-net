namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHowToApplyField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "HowToApply", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "HowToApply");
        }
    }
}
