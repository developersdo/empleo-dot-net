namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipBetweenJobOpportunitiesAndUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "UserProfileId", c => c.Int());
            CreateIndex("dbo.JobOpportunities", "UserProfileId");
            AddForeignKey("dbo.JobOpportunities", "UserProfileId", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOpportunities", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.JobOpportunities", new[] { "UserProfileId" });
            DropColumn("dbo.JobOpportunities", "UserProfileId");
        }
    }
}
