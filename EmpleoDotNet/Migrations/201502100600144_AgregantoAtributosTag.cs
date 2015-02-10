namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregantoAtributosTag : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "Name", c => c.String());
        }
    }
}
