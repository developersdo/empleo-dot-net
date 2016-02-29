using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Services.Social.Twitter
{
    public interface ITwitterService
    {
        Task PostTweet(string message);
        Task PostNewJobOpportunity(JobOpportunity jobOpportunity);
    }
}