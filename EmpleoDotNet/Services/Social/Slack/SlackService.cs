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
using EmpleoDotNet.ViewModel.Slack;
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

        public async Task PostJobOpportunityErrorResponse(JobOpportunity jobOpportunity, UrlHelper urlHelper, string responseUrl)
        {
            if (jobOpportunity == null)
            {
                var payloadObject = new PayloadRequestDto()
                {
                    text = "A new job posting has been created!",
                    replace_original = true,
                    attachments = new List<Attachment> { new Attachment {
                        fallback = "Oops! Looks like this job was removed by its author.",
                        text = "Oops! Looks like this job was removed by its author.",
                        callback_id = "0",
                        color = "danger",
                        attachment_type = "default"
                    }}
                };
                await PostNotification(payloadObject, responseUrl).ConfigureAwait(false);
            } 
            else
            {
                var payloadObject = new PayloadRequestDto()
                {
                    text = "A new job posting has been created!",
                    replace_original = true,
                    attachments = new List<Attachment> { new Attachment {
                        fallback = "Oops! Looks like something went wrong with this job posting. Log in and check " + urlHelper.AbsoluteUrl("", "elmah.axd") + " for more details.",
                        text = "Oops! Looks like something went wrong with this job posting. Log in and check " + urlHelper.AbsoluteUrl("", "elmah.axd") + " for more details.",
                        callback_id = jobOpportunity?.Id.ToString(),
                        color = "danger",
                        attachment_type = "default"
                    }}
                };
                await PostNotification(payloadObject, responseUrl).ConfigureAwait(false);
            }
        }

        public async Task PostJobOpportunityResponse(JobOpportunity jobOpportunity, UrlHelper urlHelper, string responseUrl, string userId, bool approved)
        {
            if (string.IsNullOrWhiteSpace(jobOpportunity?.Title) || jobOpportunity.Id <= 0)
                return;

            var descriptionLength = 124;
            var trimmedDescription = Regex.Replace(jobOpportunity.Description, "<.*?>", String.Empty).TrimStart();
            var limitedDescription = trimmedDescription.Length > descriptionLength
                ? trimmedDescription.Substring(0, descriptionLength) + "..."
                : trimmedDescription;
            var action = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title);
            var approvedMessage = approved ? "approved" : "rejected";

            var payloadObject = new PayloadRequestDto()
            {
                text = "A new job posting has been created!",
                replace_original = true,
                attachments = new List<Attachment> { new Attachment {
                    fallback = "Check the new posted job at " + urlHelper.AbsoluteUrl(action, "jobs"),
                    author_name = jobOpportunity.CompanyName,
                    title = jobOpportunity.Title,
                    title_link = urlHelper.AbsoluteUrl(action, "jobs"),
                    text = limitedDescription,
                    thumb_url = jobOpportunity.CompanyLogoUrl,
                    callback_id = jobOpportunity.Id.ToString(),
                    color = "#3AA3E3",
                    attachment_type = "default",
                    fields = new List<AttachmentField> { new AttachmentField {
                        title = "",
                        value = ":ballot_box_with_check: <@" + userId + "> *" + approvedMessage + " this request*",
                        @short = false
                    }}
                }}
            };

            await PostNotification(payloadObject, responseUrl).ConfigureAwait(false);
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

            var payloadObject = new PayloadRequestDto()
            {
                text = "A new job posting has been created!",
                replace_original = false,
                attachments = new List<Attachment> { new Attachment {
                    fallback = "Check the new posted job at " + urlHelper.AbsoluteUrl(action, "jobs"),
                    author_name = jobOpportunity.CompanyName,
                    title = jobOpportunity.Title,
                    title_link = urlHelper.AbsoluteUrl(action, "jobs"),
                    text = limitedDescription,
                    thumb_url = jobOpportunity.CompanyLogoUrl,
                    callback_id = jobOpportunity.Id.ToString(),      
                    color = "#3AA3E3",
                    attachment_type = "default",
                    actions = new List<AttachmentAction> { new AttachmentAction {
                        name = "approve",
                        text = "Approve",
                        style = "primary",
                        type = "button",
                        value = "approve"
                    }, new AttachmentAction {
                        name = "reject",
                        text = "Reject",
                        style = "default",
                        type = "button",
                        value = "reject"
                    }}
                }}
            };

            await PostNotification(payloadObject, _slackWebhookUrl).ConfigureAwait(false);
        }

        private async Task PostNotification(PayloadRequestDto payloadObject, string endpointUrl)
        {
            // Serialize the parameters into a JSON String that represents the message
            var stringPayload = JsonConvert.SerializeObject(payloadObject);

            // Wrap the JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Do the actual request and await the response
                var httpResponse = await httpClient.PostAsync(endpointUrl, httpContent);
            }
        }
    }
}