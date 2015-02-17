namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoTagEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagJobOpportunities",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        JobOpportunity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.JobOpportunity_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.JobOpportunities", t => t.JobOpportunity_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.JobOpportunity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagJobOpportunities", "JobOpportunity_Id", "dbo.JobOpportunities");
            DropForeignKey("dbo.TagJobOpportunities", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagJobOpportunities", new[] { "JobOpportunity_Id" });
            DropIndex("dbo.TagJobOpportunities", new[] { "Tag_Id" });
            DropTable("dbo.TagJobOpportunities");
            DropTable("dbo.Tags");
        }
    }
}
