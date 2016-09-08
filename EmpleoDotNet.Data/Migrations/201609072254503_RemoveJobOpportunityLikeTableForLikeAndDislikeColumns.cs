namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveJobOpportunityLikeTableForLikeAndDislikeColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobOpportunityLikes", "JobOpportunityId", "dbo.JobOpportunities");
            DropIndex("dbo.JobOpportunityLikes", new[] { "JobOpportunityId" });
            AddColumn("dbo.JobOpportunities", "Likes", c => c.Int(nullable: false));
            AddColumn("dbo.JobOpportunities", "DisLikes", c => c.Int(nullable: false));
            DropTable("dbo.JobOpportunityLikes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.JobOpportunities", "DisLikes");
            DropColumn("dbo.JobOpportunities", "Likes");
            CreateIndex("dbo.JobOpportunityLikes", "JobOpportunityId");
            AddForeignKey("dbo.JobOpportunityLikes", "JobOpportunityId", "dbo.JobOpportunities", "JobOpportunityId", cascadeDelete: true);
        }
    }
}
