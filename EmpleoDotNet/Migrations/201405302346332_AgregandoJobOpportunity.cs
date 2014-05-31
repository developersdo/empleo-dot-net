namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoJobOpportunity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOpportunities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        Location = c.String(),
                        Category = c.Int(nullable: false),
                        RequirementsToApply = c.String(),
                        CompanyName = c.String(),
                        CompanyUrl = c.String(),
                        CompanyEmail = c.String(),
                        CompanyLogoUrl = c.String(),
                        PublishedDate = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobOpportunities");
        }
    }
}
