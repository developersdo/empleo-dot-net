namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipBetweenJobOpportunitiesAndUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOpportunities", "User_Id", c => c.Int());
            CreateIndex("dbo.JobOpportunities", "User_Id");
            AddForeignKey("dbo.JobOpportunities", "User_Id", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOpportunities", "User_Id", "dbo.UserProfiles");
            DropIndex("dbo.JobOpportunities", new[] { "User_Id" });
            DropColumn("dbo.JobOpportunities", "User_Id");
        }
    }
}
