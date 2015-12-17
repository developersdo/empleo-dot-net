using System.Data.Entity.ModelConfiguration;

namespace EmpleoDotNet.Models.TableConfigurations
{
    /// <summary>
    /// Base Table Configuration para pre-configurar todas las tablas y sobreescribir el nombre del Campo Id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseTableConfiguration<T> : EntityTypeConfiguration<T> where T : ISearchable
    {
        protected BaseTableConfiguration()
        {
            /*Segun el diseño inicial, se deseaba que los PK todos se llamaran Id,
            Para mantener esta comodidad pero generar una DB apta para el mundo real 
            Cambiar Nombre de la columna.*/
            Property(x => x.Id).HasColumnName(string.Format("{0}Id", typeof (T).Name));
        }
    }
}