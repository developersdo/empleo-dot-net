namespace EmpleoDotNet.Models
{
    public interface ISearchable
    {
        /// <summary>
        /// Las entidades deben poseer un identificador unico para poder realizar búsquedas
        /// cuando trabajemos con colecciones.
        /// </summary>
        int Id { get; set; }
    }
}