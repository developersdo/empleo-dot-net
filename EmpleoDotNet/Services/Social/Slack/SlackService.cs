using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Helpers;
using Newtonsoft.Json;

namespace EmpleoDotNet.Services.Social.Slack
{
    public class SlackService : ISlackService
    {
        private readonly string _slackWebhookUrl;
        public SlackService()
        {
            var slackWebhookEndpoint = ConfigurationManager.AppSettings["slackWebhookEndpoint"];
            _slackWebhookUrl = "https://hooks.slack.com/services/" + slackWebhookEndpoint;
        }

        public async Task PostNewJobOpportunity(JobOpportunity jobOpportunity, UrlHelper urlHelper)
        {
            if (string.IsNullOrWhiteSpace(jobOpportunity?.Title) || jobOpportunity.Id <= 0)
                return;

            var descriptionLength = 124;
            var trimmedDescription = Regex.Replace(jobOpportunity.Description, "<.*?>", String.Empty).TrimStart();
            var limitedDescription = trimmedDescription.Length > descriptionLength
                ? trimmedDescription.Substring(0, descriptionLength) + "..."
                : trimmedDescription;

            var action = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title);
            var url = urlHelper.AbsoluteUrl(action, "jobs");
            var companyName = jobOpportunity.CompanyName;
            var logoUrl = jobOpportunity.CompanyLogoUrl;
            var title = jobOpportunity.Title;

            await PostNotification(companyName, logoUrl, title, url, limitedDescription).ConfigureAwait(false);
        }

        private async Task PostNotification(string companyName, string companyLogoUrl, string jobTitle, string jobUrl, string jobDescription)
        {
            // Serialize the parameters into a JSON String that represents the message
            var stringPayload = JsonConvert.SerializeObject(new {
                text = "A new job posting has been created!",
                attachments = new object[] { new {
                    fallback = "You are unable to choose an action",
                    author_name = companyName,
                    title = jobTitle,
                    title_link = jobUrl,
                    text = jobDescription,
                    thumb_url = companyLogoUrl,
                    callback_id = ConfigurationManager.AppSettings["slackPostValidationKey"],
                    color = "#3AA3E3",
                    attachment_type = "default",
                    actions = new object[] { new
                    {
                        name = "approve",
                        text = "Approve",
                        style = "primary",
                        type = "button",
                        value = "approve"
                    }, new {
                        name = "reject",
                        text = "Reject",
                        style = "default",
                        type = "button",
                        value = "reject"
                    }}
                }},
            });

            // Wrap the JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Do the actual request and await the response
                var httpResponse = await httpClient.PostAsync(_slackWebhookUrl, httpContent);
            }
        }
    }
}