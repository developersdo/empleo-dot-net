using Api.Contract;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.WebAPI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmpleoDotNet.WebAPI.Controllers
{
    public class JobsController : ApiController
    {
        private readonly IJobOpportunityService _jobsService;
        private readonly IJobOpportunityToMobileJobAdapter _adapter;

        public JobsController(IJobOpportunityService jobsService, IJobOpportunityToMobileJobAdapter adapter)
        {
            _jobsService = jobsService;
            _adapter = adapter;
        }

        public IHttpActionResult Get(int page = 1, int pageSize = 25)
        {
            var jobCards = GetJobCards(page, pageSize).ToList();
            var response = new JobCardListResponse(jobCards);

            return Json(response);
        }

        public IHttpActionResult GetJobDetails(string id)
        {
            int jobId = 0;
            int.TryParse(id, out jobId);
            var job = _jobsService.GetJobOpportunityById(jobId);
            var jobDetails = _adapter.GetJobDetails(job);

            return Json(jobDetails);
        }

        private IEnumerable<JobCardDTO> GetJobCards(int page, int pageSize)
        {
            var pagingParameters = new JobOpportunityPagingParameter();
            pagingParameters.Page = page;
            pagingParameters.PageSize = pageSize;

            var opportunities = _jobsService.GetAllJobOpportunitiesPagedByFilters(pagingParameters);
            var jobCards = opportunities.Select(x => _adapter.GetJobCard(x));
            return jobCards;
        }
    }
}