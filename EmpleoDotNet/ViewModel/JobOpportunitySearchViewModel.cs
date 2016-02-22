using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using PagedList;

namespace EmpleoDotNet.ViewModel
{
    public class JobOpportunitySearchViewModel
    {
        public string SelectedLocationPlaceId { get; set; }
        public string SelectedLocationName { get; set; }
        public IPagedList<Core.Domain.JobOpportunity> Result { get; set; }
        public string Keyword { get; set; }
        public JobCategory JobCategory { get; set; }
        public bool IsRemote { get; set; }
        public List<JobCategoryCountDto> CategoriesCount { get; set; }
    }
}