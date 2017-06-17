using System;
using System.Collections.Generic;

namespace EmpleoDotNet.Core.Domain
{
    public class JobOpportunity : EntityBase
    {
        #region Property
        /// <summary>
        /// Titulo de la posición
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Categoria del empleo
        /// </summary>
        public JobCategory Category { get; set; }

        /// <summary>
        /// Locacion del empleo
        /// </summary>
        public int? LocationId { get; set; }

        /// <summary>
        /// Descripción de los requerimientos necesarios para aplicar al empleo
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
        /// Flag que representa si el empleo ha sido aprovado o no para mostrarse en la pantalla principal de empleos.
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// Contador de visitas realizadas a una publicación
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// Contador de likes realizados a una publicación
        /// </summary>
        public int Likes { get; set; }

        /// <summary>
        /// Contador de dislikes realizados a una publicación
        /// </summary>
        public int DisLikes { get; set; }

        /// <summary>
        /// Especifica si el empleo es Tiempo Completo, Independiente, etc.
        /// </summary>
        public JobType JobType { get; set; }

        public int? JoelTestId { get; set; }

        public int? JobOpportunityLocationId { get; set; }

        public int? UserProfileId { get; set; } 
        /// <summary>
        /// para especificar la forma de como se aplica para el empleo
        /// </summary>
        public string HowToApply { get; set; }

        /// <summary>
        /// Flag que representa si el empleo es Remoto o no
        /// </summary>
        public bool IsRemote { get; set; }

        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Allow to hide this job opportunity from all jobs list, only vissible to the owner(company/user) of the
        /// opportunity  
        /// </summary>
        public bool IsHidden { get; set; }

       
        #endregion

        #region Navegation Properties

        public List<Tag> Tags { get; set; }

        public JoelTest JoelTest { get; set; }

        public JobOpportunityLocation JobOpportunityLocation { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public Location Location { get; set; }


        #endregion
    }
}