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
        public string HowToApply { get; set; }
        public JobDetailCompany Company { get; set;}

        public class JobDetailCompany
        {
            public string Name { get; set; }
            public string LogoUrl { get; set; }
            public string Url { get; set; }
            public string Email { get; set; }
        }
    }
}
