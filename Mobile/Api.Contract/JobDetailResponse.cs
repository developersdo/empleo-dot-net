using System;
using System.Threading.Tasks;

namespace Api.Contract
{
	public class JobDetailResponse
	{
		public string Link { get; set; }

		public string JobTitle { get; set; }

		public string JobDescription { get; set; }

		public string JobType { get; set; }

		public string Location { get; set; }

		public int Visits { get; set; }

		public bool IsRemote { get; set; }

		public string CompanyName { get; set; }

		public string CompanyEmail { get; set; }
	}
}
