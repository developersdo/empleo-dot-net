namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixSomeJoelTestFields : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.JoelTests", "HasBusFixedBeforeProceding", "HasBugsFixedBeforeProceding");
            RenameColumn("dbo.JoelTests", "HasQuiteEnvironment", "HasQuietEnvironment");
            RenameColumn("dbo.JoelTests", "HasBugDatabase", "HasBugsDatabase");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.JoelTests", "HasBugsFixedBeforeProceding","HasBusFixedBeforeProceding");
            RenameColumn("dbo.JoelTests", "HasQuietEnvironment","HasQuiteEnvironment");
            RenameColumn("dbo.JoelTests", "HasBugsDatabase", "HasBugDatabase");
        }
    }
}