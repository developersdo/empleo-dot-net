using System;
using System.Threading.Tasks;

namespace Api.Contract
{
	public class JobDetailResponse
	{
		public string Link { get; set; }

		public string Job { get; set; }

		public string Employee { get; set; }

		public string JobType { get; set; }

		public string Location { get; set; }

		public bool IsRemote { get; set; }

		public string JobDetail { get; set; }

		public string AboutCompany { get; set; }

		public string CompanyEmail { get; set; }
	}

}

