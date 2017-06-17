using System;
using System.Threading.Tasks;
using System.Collections.Generic;
//using Refit;
using System.Threading;

namespace Api.Contract
{
//	[Headers("Accept: application/json")]
	public interface IJobsApiService
	{
//		[Get("/jobs")]
		Task<JobCardListResponse> GetCardJobs(int page = 1, int pageSize = 25, CancellationToken token = default(CancellationToken));

//		[Get("/jobs/{id}")]
		Task<JobDetailResponse> GetJobDetailForId(string id, CancellationToken token = default(CancellationToken));
	}
}