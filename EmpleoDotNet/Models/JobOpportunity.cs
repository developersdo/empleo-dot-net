using System;

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
        
        public JobCategory Category { get; set; }
        
        public string RequirementsToApply { get; set; }
        
        public string CompanyName { get; set; }
        
        public string CompanyUrl { get; set; }
        
        public string CompanyEmail { get; set; }
        
        public string CompanyLogoUrl { get; set; }
        
        public DateTime PublishedDate { get; set; }
    }
}