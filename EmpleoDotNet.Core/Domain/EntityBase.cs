using System;

namespace EmpleoDotNet.Core.Domain
{
    /// <summary>
    /// Clase base de donde heredan todas las entidades del sistema. 
    /// Evita repetición de código y ayuda a mantener los modelos limpios
    /// </summary>
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Created = DateTime.Now;
        }

        /// <summary>
        /// Identificador unico de una entidad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Las entidades deben poseer un campo con la fecha de creación para posibles 
        /// auditorias o como referencia en potenciales sesiones de debugging.
        /// </summary>
        public DateTime Created { get; set; }
    }
}