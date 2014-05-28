using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models.Entities
{
    /// <summary>
    /// Las entidades deben poseer un identificador unico para poder buscar entidades especificas cuando trabajemos con colecciones.
    /// Las entidades deben poseer un campo con la fecha de creación para posibles auditorias o como referencia en potenciales sesiones de debugging.
    /// </summary>
    public class Entity
    {
        public Int32 Id { get; set; }

        public DateTime Created { get; set; }
    }
}