namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoEstadoRegistro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "Estado");
        }
    }
}
