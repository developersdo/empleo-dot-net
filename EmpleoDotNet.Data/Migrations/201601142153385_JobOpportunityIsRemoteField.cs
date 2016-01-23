using System.Data.Entity.Migrations;

namespace EmpleoDotNet.Data.Migrations
{
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
