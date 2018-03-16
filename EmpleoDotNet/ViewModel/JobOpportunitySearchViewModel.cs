using System.Collections.Generic;
using System.Web.Mvc;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using PagedList;

namespace EmpleoDotNet.ViewModel
{
    public class JobOpportunitySearchViewModel
    {
        public string SelectedLocationPlaceId { get; set; }
        public string SelectedLocationName { get; set; }
        public string SelectedLocationLatitude { get; set; }
        public string SelectedLocationLongitude { get; set; }
        public decimal LocationDistance { get; set; } = 15M;
        public IPagedList<Core.Domain.JobOpportunity> Result { get; set; } = new PagedList<Core.Domain.JobOpportunity>(null, 1, 15);
        public string Keyword { get; set; }
        public JobCategory JobCategory { get; set; }
        public bool IsRemote { get; set; }
        public List<JobCategoryCountDto> CategoriesCount { get; set; }
        public IList<SelectListItem> PageList { get; set; }
    }
}