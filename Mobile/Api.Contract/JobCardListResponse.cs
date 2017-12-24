using System;
using System.Collections.Generic;

namespace Api.Contract
{
	public class JobCardListResponse
	{
        public JobCardListResponse() { }
        public JobCardListResponse(List<JobCardDTO> jobs)
        {
            Jobs = jobs;
        }
		public List<JobCardDTO> Jobs;
	}
}