using System;
using Api.Contract;
using System.Threading.Tasks;
using System.Collections.Generic;
using APIs;
using System.Threading;

namespace Api
{
	public class JobsApiService : IJobsApiService
	{
		IProxy _proxy;

		public JobsApiService (IProxy proxy)
		{
			_proxy = proxy;
		}

		public async Task<JobCardListResponse> GetCardJobs (int page = 1, int pageSize = 25, CancellationToken token = default(CancellationToken))
		{
			var result = await _proxy.Get<JobCardListResponse>(Constants.JobsEndpoint, Method.GET, token: token);

			return result.Result;
		}

		public async Task<JobDetailResponse> GetJobDetailForId (string id, CancellationToken token)
		{
			var result = await _proxy.Get<JobDetailResponse>(Constants.JobsEndpoint, Method.GET, 
				new List<Parameter>
				{
					new Parameter
					{
						Property = "title",
						Value = "demo"
					},
					new Parameter
					{
						Property = "id",
						Value = "4035"
					}
				}
				,token: token);

			return result.Result;
		}
	}
}

