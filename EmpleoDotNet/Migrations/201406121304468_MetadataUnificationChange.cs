namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// Esta migración es el resultado de Unificar la metadata del modelo.
    /// Previamente el (JobOpportunityViewModel) tenia las validaciones pero
    /// el verdadero modelo de datos de EF (JobOpportunity) no las tenia.
    /// 
    /// El resultado de esto era que las columnas de la tabla generada eran 
    /// mayormente nullable, y el UI validaba como required. En este caso 
    /// el codigo estaba duplicado y out of sync. Cosa que solo iba a 
    /// empeorar con el tiempo.
    /// </summary>
    public partial class MetadataUnificationChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobOpportunities", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.JobOpportunities", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.JobOpportunities", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.JobOpportunities", "CompanyName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.JobOpportunities", "CompanyEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobOpportunities", "CompanyEmail", c => c.String());
            AlterColumn("dbo.JobOpportunities", "CompanyName", c => c.String(maxLength: 50));
            AlterColumn("dbo.JobOpportunities", "Description", c => c.String());
            AlterColumn("dbo.JobOpportunities", "Location", c => c.String());
            AlterColumn("dbo.JobOpportunities", "Title", c => c.String());
        }
    }
}
