using System.Data.Entity.Migrations;

namespace EmpleoDotNet.Data.Migrations
{
    public partial class AddViewCountColumn : DbMigration
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
