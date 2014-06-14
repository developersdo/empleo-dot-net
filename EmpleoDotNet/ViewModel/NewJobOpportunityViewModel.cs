using System;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.ViewModel
{
    /// <summary>
    /// ViewModel para crear una vacante nueva
    /// </summary>
    [MetadataType(typeof(JobOpportunity))] //Includes Data Validations of Model
    public class NewJobOpportunityViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Location { get; set; }

        public JobCategory Category { get; set; }
        
        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string CompanyUrl { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyLogoUrl { get; set; }

        public DateTime Created { get { return DateTime.Now; } }
        public DateTime PublishedDate { get { return DateTime.Now; } }


        public Models.JobOpportunity ToEntity()
        {

            var entity = new JobOpportunity
            {
                Title = this.Title,
                Location = this.Location,
                Category = this.Category,
                Description = this.Description,
                CompanyName = this.CompanyName,
                CompanyUrl = this.CompanyUrl,
                CompanyLogoUrl = this.CompanyLogoUrl,
                CompanyEmail = this.CompanyEmail,
                Created = this.Created,
                PublishedDate = this.PublishedDate
            };

            return entity;
        }
    }
}