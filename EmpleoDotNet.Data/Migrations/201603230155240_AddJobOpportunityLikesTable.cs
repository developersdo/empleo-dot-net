namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobOpportunityLikesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOpportunityLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Like = c.Boolean(nullable: false),
                        JobOpportunityId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOpportunities", t => t.JobOpportunityId, cascadeDelete: true)
                .Index(t => t.JobOpportunityId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOpportunityLikes", "JobOpportunityId", "dbo.JobOpportunities");
            DropIndex("dbo.JobOpportunityLikes", new[] { "JobOpportunityId" });
            DropTable("dbo.JobOpportunityLikes");
        }
    }
}
