namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobOpportunityLikes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOpportunityLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Like = c.Boolean(nullable: false),
                        JobOpportinutyId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOpportunities", t => t.JobOpportinutyId, cascadeDelete: true)
                .Index(t => t.JobOpportinutyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOpportunityLikes", "JobOpportinutyId", "dbo.JobOpportunities");
            DropIndex("dbo.JobOpportunityLikes", new[] { "JobOpportinutyId" });
            DropTable("dbo.JobOpportunityLikes");
        }
    }
}
