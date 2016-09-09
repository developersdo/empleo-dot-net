namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSecurityTables : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Roles(Name) values ('Client') ");
            Sql("Insert into Roles(Name) values ('Moderator') ");
        }
        
        public override void Down()
        {
        }
    }
}
