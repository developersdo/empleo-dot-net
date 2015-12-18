using System;
using System.Collections.Generic;

namespace EmpleoDotNet.Models
{
    public class JobOpportunity : EntityBase
    { 
        #region Property
        /// <summary>
        /// Titulo de la posición
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Posición geográfica (donde es el trabajo)
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Categoria del trabajo
        /// </summary>
        public JobCategory Category { get; set; }

        /// <summary>
        /// Descripción de los requerimientos necesarios para aplicar al trabajo
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Nombre de la compañía
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Dirección Website de la empresa
        /// </summary>
        public string CompanyUrl { get; set; }

        /// <summary>
        /// E-mail de contacto de la empresa
        /// </summary>
        public string CompanyEmail { get; set; }

        /// <summary>
        /// Logo de la empresa
        /// </summary>
        public string CompanyLogoUrl { get; set; }

        /// <summary>
        /// Fecha de publicación. 
        /// </summary>
        /// <remarks>
        /// Este campo se usa para poder hacer un "draft" antes de publicar, 
        /// o para decidir si desplegar o no una oferta luego de que el cliente pague
        /// </remarks>
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// Flag que representa si el trabajo ha sido aprovado o no para mostrarse en la pantalla principal de empleos.
        /// </summary>
        public bool Approved { get; set; }

        #endregion

        #region Navegation Properties

        public List<Tag> Tags { get; set; }

        public Location Location { get; set; }

        #endregion
    }
}