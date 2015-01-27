namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagsId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        TagCount = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TagsId);
            
            AddColumn("dbo.JobOpportunities", "Tag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOpportunities", "Tag");
            DropTable("dbo.Tags");
        }
    }
}
