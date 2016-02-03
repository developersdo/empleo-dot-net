namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingJoelTestentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JoelTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HasSourceControl = c.Boolean(nullable: false),
                        HasOneStepBuilds = c.Boolean(nullable: false),
                        HasDailyBuilds = c.Boolean(nullable: false),
                        HasBugDatabase = c.Boolean(nullable: false),
                        HasBusFixedBeforeProceding = c.Boolean(nullable: false),
                        HasUpToDateSchedule = c.Boolean(nullable: false),
                        HasSpec = c.Boolean(nullable: false),
                        HasQuiteEnvironment = c.Boolean(nullable: false),
                        HasBestTools = c.Boolean(nullable: false),
                        HasTesters = c.Boolean(nullable: false),
                        HasWrittenTest = c.Boolean(nullable: false),
                        HasHallwayTests = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.JobOpportunities", "JoelTest_Id", c => c.Int());
            CreateIndex("dbo.JobOpportunities", "JoelTest_Id");
            AddForeignKey("dbo.JobOpportunities", "JoelTest_Id", "dbo.JoelTests", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOpportunities", "JoelTest_Id", "dbo.JoelTests");
            DropIndex("dbo.JobOpportunities", new[] { "JoelTest_Id" });
            DropColumn("dbo.JobOpportunities", "JoelTest_Id");
            DropTable("dbo.JoelTests");
        }
    }
}
