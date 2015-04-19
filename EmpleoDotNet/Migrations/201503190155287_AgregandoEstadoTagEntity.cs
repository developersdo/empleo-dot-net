namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoEstadoTagEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tags", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Estado", c => c.Int(nullable: false));
        }
    }
}
