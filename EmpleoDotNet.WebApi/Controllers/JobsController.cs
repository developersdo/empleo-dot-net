using Api.Contract;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Core.Domain;
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

        [Route("api/jobs/")]
        public IHttpActionResult Get(int page = 1, int pageSize = 2)
        {

            var pagingParameters = new JobOpportunityPagingParameter();
            pagingParameters.Page = page;
            pagingParameters.PageSize = pageSize;

            // We should really take advantage of the fact that we have a PagedList
            var opportunities = _jobsService.GetAllJobOpportunitiesPagedByFilters(pagingParameters);

            var jobCards = GetJobCards(opportunities);


            var response = new JobCardListResponse()
            {
                Jobs = jobCards,
                PageSize = opportunities.PageSize,
                PageNumber = opportunities.PageNumber,
                PagesCount= opportunities.PageCount,
                TotalItemCount = opportunities.TotalItemCount
            };

            return Json(response);
        }



        [Route("api/jobs/search/")]
        [HttpGet]
        public IHttpActionResult Search(string keyword = "", bool isRemote = false, int page = 1, int pageSize = 2)
        {

            var pagingParameters = new JobOpportunityPagingParameter();
            pagingParameters.Keyword = keyword;
            pagingParameters.IsRemote = isRemote;
            pagingParameters.Page = page;
            pagingParameters.PageSize = pageSize;

            // We should really take advantage of the fact that we have a PagedList
            var opportunities = _jobsService.GetAllJobOpportunitiesPagedByFilters(pagingParameters);

            var jobCards = GetJobCards(opportunities);


            var response = new JobCardListResponse()
            {
                Jobs = jobCards,
                PageSize = opportunities.PageSize,
                PageNumber = opportunities.PageNumber,
                PagesCount = opportunities.PageCount,
                TotalItemCount = opportunities.TotalItemCount
            };

            return Json(response);
        }


        [Route("api/jobs/detail/{id}")]
        [HttpGet]
        public IHttpActionResult Detail(string id)
        {
            int jobId = 0;
            int.TryParse(id, out jobId);
            var job = _jobsService.GetJobOpportunityById(jobId);
            var jobDetails = _adapter.GetJobDetails(job);

            return Json(jobDetails);
        }

        private IEnumerable<JobCardDTO> GetJobCards(IEnumerable<JobOpportunity> jobOpportunities)
        {
            var jobCards = jobOpportunities.Select(x => _adapter.GetJobCard(x));
            return jobCards;
        }
    }
}