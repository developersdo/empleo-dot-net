using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.ViewModel
{
    /// <summary>
    /// ViewModel para crear una vacante nueva
    /// </summary>
    public class NewJobOpportunityViewModel
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public JobCategory Category { get; set; }

        public string RequirementsToApply { get; set; }
   
        public string CompanyName { get; set; }

        public string CompanyUrl { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyLogoUrl { get; set; }

        public Models.JobOpportunity ToEntity()
        {

            var entity = new JobOpportunity {
                Title = this.Title,
                Location = this.Location,
                Category = this.Category,
                RequirementsToApply = this.RequirementsToApply,
                CompanyName = this.CompanyName,
                CompanyUrl = this.CompanyUrl,
                CompanyLogoUrl = this.CompanyLogoUrl,
                CompanyEmail = this.CompanyEmail
            };

            return entity;
        }
    }
}