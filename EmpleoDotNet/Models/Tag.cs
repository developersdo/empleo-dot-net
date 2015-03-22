using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    public class Tag: EntityBase
    {
        #region Property
        /// <summary>
        /// Nombre del tag
        /// </summary>
        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(50, ErrorMessage = "Este campo no puede contener mas de 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        /// <summary>
        /// Estado del registro
        /// </summary> 
        public EstadoRegistro Estado { get; set; }
        #endregion

        #region Navegation Properties
        public ICollection<JobOpportunity> Opportunities { get; set; } 
        #endregion
    }
}