using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

namespace Api.Contract
{
	[Headers("Accept: application/json")]
	public interface IJobsApiService
	{
		[Get("/cardJobs")]
		Task<JobCardListResponse> GetCardJobs(int limit = 25);

		[Get("/jobs/{id}")]
		Task<JobDetailResponse> GetJobDetailForId(string id);
	}
}