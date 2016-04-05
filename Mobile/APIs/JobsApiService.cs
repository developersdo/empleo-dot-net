using System;
using Api.Contract;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;
using APIs;

namespace Api
{
	public class JobsApiService : IJobsApiService
	{
		IJobsApiService _jobsAPi;

		public JobsApiService ()
		{
			_jobsAPi = RestService.For<IJobsApiService> (Constants.Endpoint);
		}

		public async Task<JobCardListResponse> GetCardJobs (int limit = 25)
		{
			return await _jobsAPi.GetCardJobs();
		}

		public async Task<JobDetailResponse> GetJobDetailForId (string id)
		{
			return await _jobsAPi.GetJobDetailForId(id);
		}
	}
}

