using EmpleoDotNet.Models;

namespace EmpleoDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Esta migración es el resultado de actualizar el diseño del Modelo.
    /// Previamente el <see cref="EntityBase"/> implementaba una propiedad Id
    /// que aparentemente seria el unique Id en todas las entidades del modelo
    /// y serviria para busquedas.
    /// 
    /// El codigo fue refactored para lograr:
    /// 
    ///     1 - Habilitar a cada Entidad definir la metadata y validación de su Id
    ///     2 - Aumentar la claridad del modelo (para entender una entidad solo hay que ver la clase que la define)
    ///     3 - Separar implementación (<see cref="EntityBase"/>, de funcionalidad esperada <see cref="ISearchable"/>.
    ///     4 - In the wild, no es realista que los Ids de todas las tablas generadas for EF se 
    ///         llamen "Id" (i.e. cuando entran a la ecuación las Foreign Keys). El cambio refleja esto.
    /// </summary>
    public partial class ModificacionDePrimaryKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobOpportunities", name: "Id", newName: "JobOpportunityId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.JobOpportunities", name: "JobOpportunityId", newName: "Id");
        }
    }
}
