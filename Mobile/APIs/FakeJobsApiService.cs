using System;
using Api;
using Api.Contract;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APIs
{
	public class FakeJobsApiService : IJobsApiService
	{
		public async Task<JobCardListResponse> GetCardJobs (int limit = 25)
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

		public async Task<JobDetailResponse> GetJobDetailForId (string id)
		{
			return await Task.Run<JobDetailResponse>(()=>
				{
					return new JobDetailResponse
					{
						Job = "Hello World 4",
						Employee = "Megsoft Consulting",
						JobType = "Mobile Development",
						Location = "New york",
						IsRemote = true
					};
				});
		}

	}
}

