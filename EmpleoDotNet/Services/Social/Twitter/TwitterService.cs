using System.Configuration;
using System.Threading.Tasks;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Core.Domain;
using Tweetinvi;
using EmpleoDotNet.Helpers;
using Ninject;

namespace EmpleoDotNet.Services.Social.Twitter
{
    public class TwitterService : ITwitterService
    {
        public TwitterService(ISettingsProvider settings)
        {
            var consumerKey = settings.Get("consumerKey");
            var consumerSecret = settings.Get("consumerSecret");
            var accessToken = settings.Get("accessToken");
            var accessTokenSecret = settings.Get("accessTokenSecret");

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

        public async Task PostNewJobOpportunity(JobOpportunity jobOpportunity)
        {
            if (string.IsNullOrWhiteSpace(jobOpportunity?.Title) || jobOpportunity.Id <= 0)
                return;

            var title = jobOpportunity.Title.Length > 80 
                ? jobOpportunity.Title.Substring(0, 80) 
                : jobOpportunity.Title;

            var message = $"Se busca: {title} http://emplea.do/JobOpportunity/Detail/{UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title)}";

            await PostTweet(message).ConfigureAwait(false);
        }
    }
}