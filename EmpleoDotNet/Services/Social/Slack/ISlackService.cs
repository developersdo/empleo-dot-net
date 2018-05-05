using EmpleoDotNet.Core.Domain;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmpleoDotNet.Services.Social.Slack
{
    public interface ISlackService
    {
        Task PostNewJobOpportunity(JobOpportunity jobOpportunity, UrlHelper urlHelper);
        Task PostJobOpportunityResponse(JobOpportunity jobOpportunity, UrlHelper urlHelper, string responseUrl, string userId, bool approved);
        Task PostJobOpportunityErrorResponse(JobOpportunity jobOpportunity, UrlHelper urlHelper, string responseUrl);
    }
}
