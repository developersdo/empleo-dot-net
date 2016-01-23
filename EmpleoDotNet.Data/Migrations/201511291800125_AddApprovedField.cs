using System.Data.Entity.Migrations;

namespace EmpleoDotNet.Data.Migrations
{
    public partial class AddApprovedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "Approved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "Approved");
        }
    }
}
