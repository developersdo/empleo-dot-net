using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpleoDotNet.Core.Domain;
using Ninject.Infrastructure.Language;

namespace EmpleoDotNet.ViewModel.JobOpportunity
{
    public class DetailsViewModel
    {
        public DetailsViewModel(Core.Domain.JobOpportunity jobOpportunity)
        {
            foreach (var property in jobOpportunity.GetType().GetProperties())
            {
                var value = jobOpportunity.GetType().GetProperty(property.Name).GetValue(jobOpportunity);
                if(value != null && this.GetType().GetProperty(property.Name) != null)
                {
                    this.GetType().GetProperty(property.Name).SetValue(this, value);
                }
            }
        }
        public Int32 Id { get; set; }
        public string Title { get; set; }

        public JobCategory Category { get; set; }
        
        public int? LocationId { get; set; }
        
        public string Description { get; set; }
        
        public string CompanyName { get; set; }

        public string CompanyUrl { get; set; }
        
        public string CompanyEmail { get; set; }
        
        public string CompanyLogoUrl { get; set; }

        public DateTime? PublishedDate { get; set; }
        
        public bool Approved { get; set; }
        
        public bool IsRemote { get; set; }

        public int ViewCount { get; set; }

        public int? JoelTestId { get; set; }

        public DateTime Created { get; set; }

        public int? JobOpportunityLocationId { get; set; }

        public List<Tag> Tags { get; set; }

        public JoelTest JoelTest { get; set; }

        public JobOpportunityLocation JobOpportunityLocation { get; set; }

        public Location Location { get; set; }
        public List<Core.Domain.JobOpportunity> RelatedJobs { get; set; }
    }
}