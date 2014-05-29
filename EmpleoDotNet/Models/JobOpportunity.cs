using System;

namespace EmpleoDotNet.Models
{
    public class JobOpportunity
    {
        public Int32 JobOpportunityId { get; set; }
        public String Place { get; set; }
        public JobCategory Category { get; set; }
        public String Profile { get; set; }
        public String RequirementsToApply { get; set; }
        public String CompanyName { get; set; }
        public String CompanyUrl { get; set; }
        public String CompanyEmail { get; set; }
        public Byte?[] CompanyLogo { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}