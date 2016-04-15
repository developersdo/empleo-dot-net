using System;
using System.Collections.Generic;

namespace EmpleoDotNet.Core.Domain
{
    public class JobOpportunity : EntityBase
    {
        #region Property
        /// <summary>
        /// Title of the position
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Category of the job
        /// </summary>
        public JobCategory Category { get; set; }

        /// <summary>
        /// Location of the job
        /// </summary>
        public int? LocationId { get; set; }

        /// <summary>
        /// General description of the position
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Description of the requirements
        /// </summary>
        public string Requirements { get; set; }
  
         /// <summary>
         /// Description of the benefits
         /// </summary>
         public string Benefits { get; set; }

        /// <summary>
        /// Name of the company
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Direction of the company's website
        /// </summary>
        public string CompanyUrl { get; set; }

        /// <summary>
        /// E-mail of the company's contact
        /// </summary>
        public string CompanyEmail { get; set; }

        /// <summary>
        /// Logo of the company
        /// </summary>
        public string CompanyLogoUrl { get; set; }

        /// <summary>
        /// Date of the publication. 
        /// </summary>
        /// <remarks>
        /// This field is used to make a "draft" before publishing,
        /// or to decide whether to show an offer before the client pays or not.
        /// </remarks>
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// Flag which represents whether the job has been approved to be shown in the job's main page or not.
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// Flag which represents whether the job is remote or not.
        /// </summary>
        public bool IsRemote { get; set; }


        /// <summary>
        /// View's counter of a publication.
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// Specify if the job is Full Time, Independent, etc.
        /// </summary>
        public JobType JobType { get; set; }

        public int? JoelTestId { get; set; }

        public bool IsActive { get; set; } = true;

        public int? JobOpportunityLocationId { get; set; }

        public int? UserProfileId { get; set; } 
        /// <summary>
        /// Specify the way to apply to a job.
        /// </summary>
        public string HowToApply { get; set; }

        #endregion

        #region Navegation Properties

        public List<Tag> Tags { get; set; }

        public JoelTest JoelTest { get; set; }

        public JobOpportunityLocation JobOpportunityLocation { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public Location Location { get; set; }

        public List<JobOpportunityLike> JobOpportunityLikes { get; set; }

        #endregion
    }
}