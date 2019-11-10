using System;
using System.Collections.Generic;

namespace Api.Contract
{
	public class JobCardListResponse
	{
        public int PageSize { get; set; }
        public int PagesCount { get; set; }
        public int PageNumber { get; set; }
        public int TotalItemCount { get; set; }
        public IEnumerable<JobCardDTO> Jobs;
    }
}