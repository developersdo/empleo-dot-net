using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Helpers
{
    public static class ListExtentions
    {
        /// <summary>
        /// Convert JobOpportunity List into SyndicationItem List for use it on syndicationFeed
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<SyndicationItem> ToSyndicationList(this IEnumerable<JobOpportunity> source)
        {
            return source.Select(jobOpportunity => jobOpportunity.ToSyndicationItem()).ToList();
        }

        /// <summary>
        /// Convert JobOpportunity into SyndicationItem
        /// </summary>
        /// <param name="jobOpportunity"></param>
        /// <returns></returns>
        private static SyndicationItem ToSyndicationItem(this JobOpportunity jobOpportunity)
        {
            return new SyndicationItem()
            {
                Title = new TextSyndicationContent(jobOpportunity.Title),
                Summary = new TextSyndicationContent(jobOpportunity.Description),
                PublishDate = new DateTimeOffset(jobOpportunity.Created)
            };
        }
    }
}