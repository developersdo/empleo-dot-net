using System.Web.Mvc;
using EmpleoDotNet.Models;
using EmpleoDotNet.Models.Dto;
using PagedList;

namespace EmpleoDotNet.ViewModel
{
    public class JobOpportunitySearchViewModel
    {
        public int SelectedLocation { get; set; }
        
        public SelectList Locations { get; set; }

        public IPagedList<JobOpportunity> Result { get; set; }

        public string Keyword { get; set; }
        public JobCategory JobCategory { get; set; }
    }
}