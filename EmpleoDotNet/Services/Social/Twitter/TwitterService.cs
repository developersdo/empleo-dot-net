using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using EmpleoDotNet.Core.Domain;
using Tweetinvi;
using EmpleoDotNet.Helpers;

namespace EmpleoDotNet.Services.Social.Twitter
{
    public class TwitterService : ITwitterService
    {
        public TwitterService()
        {
            var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            var accessToken = ConfigurationManager.AppSettings["accessToken"];
            var accessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"];

            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
        }

        public async Task PostTweet(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            await Sync.ExecuteTaskAsync(() =>
            {
                Tweet.PublishTweet(message);
            }).ConfigureAwait(false);
        }

        public async Task PostNewJobOpportunity(JobOpportunity jobOpportunity, UrlHelper urlHelper)
        {
            if (string.IsNullOrWhiteSpace(jobOpportunity?.Title) || jobOpportunity.Id <= 0)
                return;

            var title = jobOpportunity.Title.Length > 80 
                ? jobOpportunity.Title.Substring(0, 80) 
                : jobOpportunity.Title;

            var action = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title);
            var url = urlHelper.AbsoluteUrl(action,"jobs");           
            var message = $"Se busca: {title} {url}";

            await PostTweet(message).ConfigureAwait(false);
        }
    }
}