using System.Collections.Generic;

namespace EmpleoDotNet.Core.Domain
{
    public class Tag: EntityBase
    {
        #region Property
        /// <summary>
        /// Nombre del tag
        /// </summary>
        //[Required(ErrorMessage = "Este campo es requerido")]
        //[MaxLength(50, ErrorMessage = "Este campo no puede contener mas de 50 caracteres")]
        //[Display(Name = "Nombre")]
        public string Name { get; set; }
        #endregion

        #region Navegation Properties
        public List<JobOpportunity> Opportunities { get; set; } 
        #endregion
    }
}