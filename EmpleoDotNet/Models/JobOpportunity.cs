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
        public String Location { get; set; }
        public JobCategory Category { get; set; }
        
        //TODO: Que es Profile?
        public String Profile { get; set; }
        public String RequirementsToApply { get; set; }
        public String CompanyName { get; set; }
        public String CompanyUrl { get; set; }
        public String CompanyEmail { get; set; }
        public Byte?[] CompanyLogo { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}