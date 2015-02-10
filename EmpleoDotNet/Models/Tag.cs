using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    public class Tag : EntityBase
    {
        #region Properties

        /// <summary>
        /// Nombre del tag
        /// </summary>
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(30,ErrorMessage = "Este campo no puede contener mas de 30 caracteres")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

 
        #endregion

        #region Navigation Property
        public ICollection<JobOpportunity> JobOpportunity { get; set; } 
        #endregion
    }
}