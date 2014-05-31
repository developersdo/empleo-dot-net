using System;
using System.ComponentModel.DataAnnotations;

namespace EmpleoDotNet.Models
{
    public class JobOpportunity : EntityBase
    {
        /// <summary>
        /// Titulo de la posición
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Posición geográfica (donde es el trabajo)
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// Categoria del trabajo
        /// </summary>
        public JobCategory Category { get; set; }
        
        /// <summary>
        /// Descripción de los requerimientos necesarios para aplicar al trabajo
        /// </summary>
        public string RequirementsToApply { get; set; }
        
        /// <summary>
        /// Nombre de la compañía
        /// </summary>
        [StringLength(50)] //TODO: Los data annotations ensucian el modelo. Deberiamos usar Fluent API
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
    }
}