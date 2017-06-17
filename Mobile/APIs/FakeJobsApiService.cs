using System;
using Api;
using Api.Contract;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace APIs
{
	public class FakeJobsApiService : IJobsApiService
	{
		public async Task<JobCardListResponse> GetCardJobs (int from, int limit = 25, CancellationToken token = default(CancellationToken))
		{
			return await Task.Run<JobCardListResponse>(()=>
				{
					return new JobCardListResponse
					{
						Jobs = new List<JobCardDTO>
						{
							new JobCardDTO
							{
								Job = "Hello World 1",
								Employee = "Megsoft Consulting",
								JobType = "Mobile Development",
								Location = "New york",
								IsRemote = true,
								Link = "1"
							},
							new JobCardDTO
							{
								Job = "Hello World 2",
								Employee = "Megsoft Consulting",
								JobType = "Mobile Development",
								Location = "New york",
								IsRemote = true
							},
							new JobCardDTO
							{
								Job = "Hello World 3",
								Employee = "Megsoft Consulting",
								JobType = "Mobile Development",
								Location = "New york",
								IsRemote = true
							},
							new JobCardDTO
							{
								Job = "Hello World 4",
								Employee = "Megsoft Consulting",
								JobType = "Mobile Development",
								Location = "New york",
								IsRemote = true
							}
						}
					};
				});
		}

		public async Task<JobDetailResponse> GetJobDetailForId (string id, CancellationToken token)
		{
			return await Task.Run<JobDetailResponse>(()=>
				{
					return new JobDetailResponse
					{
						JobTitle = "Hello World 4",
						CompanyName = "Megsoft Consulting",
						CompanyEmail = "dev@null.com",
						JobType = "Mobile Development",
						JobDescription = "This is a fake job.",
						Location = "New york",
						Visits = 40,
						IsRemote = true
					};
				});
		}

	}
}

