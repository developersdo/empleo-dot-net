using Api.Contract;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.WebAPI.Helpers;

namespace EmpleoDotNet.WebAPI.Services
{
    public interface IJobOpportunityToJobCardAdapter
    {
        JobCardDTO Convert(JobOpportunity jobOpportunity);
    }

    public class JobOpportunityToJobCardAdapter : IJobOpportunityToJobCardAdapter
    {
        public JobCardDTO Convert(JobOpportunity jobOpportunity)
        {
            var jobCard = new JobCardDTO();
            jobCard.CompanyName = jobOpportunity.CompanyName;
            jobCard.IsRemote = jobOpportunity.IsRemote;
            jobCard.Job = jobOpportunity.Description;
            jobCard.JobType = jobOpportunity.JobType.GetDisplayName();
            jobCard.Link = jobOpportunity.Id.ToString();
            jobCard.Location = jobOpportunity.Location != null ? jobOpportunity.Location.Name : "N/A";

            return jobCard;
        }
    }
}