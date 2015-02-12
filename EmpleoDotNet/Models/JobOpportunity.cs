using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleoDotNet.Models
{
    public class JobOpportunity : EntityBase, ISearchable
    {
        #region Property
        /// <summary>
        /// Titulo de la posición
        /// </summary>
        [Required(ErrorMessage = "El campo titulo es requerido."), StringLength(int.MaxValue)]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        /// <summary>
        /// Posición geográfica (donde es el trabajo)
        /// </summary>
        [Required(ErrorMessage = "La localidad es requerida")]
        [ForeignKey("Location")]
        public int LocationId { get; set; }
 
        /// <summary>
        /// Categoria del trabajo
        /// </summary>
        [Required(ErrorMessage = "Debe elegir una categoria.")]
        [Display(Name = "Categoria")]
        public JobCategory Category { get; set; }

        /// <summary>
        /// Descripción de los requerimientos necesarios para aplicar al trabajo
        /// </summary>
        [Required(ErrorMessage = "Debe especificar al menos un requisito."), StringLength(int.MaxValue)]
        [Display(Name = "Requisitos para aplicar")]
        public string Description { get; set; }

        /// <summary>
        /// Nombre de la compañía
        /// </summary>
        [Required(ErrorMessage = "El nombre de la empresa es requerido."), StringLength(50)]
        [Display(Name = "Nombre")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Dirección Website de la empresa
        /// </summary>
        [StringLength(int.MaxValue), Url(ErrorMessage = "La dirección Web de la compañia debe ser un Url valido.")]
        [Display(Name = "Dirección Web")]
        public string CompanyUrl { get; set; }

        /// <summary>
        /// E-mail de contacto de la empresa
        /// </summary>
        [Required(ErrorMessage = "El campo email es requerido"),StringLength(int.MaxValue)]
        [Display(Name = "Email"), EmailAddress(ErrorMessage = "Email invalido.")]
        public string CompanyEmail { get; set; }

        /// <summary>
        /// Logo de la empresa
        /// </summary>
        [StringLength(int.MaxValue), Url(ErrorMessage = "El Logo de la compañia debe ser un Url valido.")]
        [Display(Name = "Logo")]
        public string CompanyLogoUrl { get; set; }

        /// <summary>
        /// Fecha de publicación. 
        /// </summary>
        /// <remarks>
        /// Este campo se usa para poder hacer un "draft" antes de publicar, 
        /// o para decidir si desplegar o no una oferta luego de que el cliente pague
        /// </remarks>
        [Display(Name = "Fecha de Publicación")]
        public DateTime? PublishedDate { get; set; }
        #endregion

        #region Navegation Properties
        public List<Tag> Tags { get; set; }

        [Display(Name = "Localidad")]
        public Location Location { get; set; }
        #endregion

    }
}