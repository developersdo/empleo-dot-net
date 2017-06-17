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

            var length = 80;
            var hashtag = string.Empty;

            if (jobOpportunity.IsRemote)
            {
                length = 64;
                hashtag = " #weworkremotely";
            }

            var title = jobOpportunity.Title.Length > length
                ? jobOpportunity.Title.Substring(0, length)
                : jobOpportunity.Title;

            var action = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title);
            var url = urlHelper.AbsoluteUrl(action, "jobs");
            var message = $"Se busca: {title}{hashtag} {url}";

            await PostTweet(message).ConfigureAwait(false);
        }
    }
}