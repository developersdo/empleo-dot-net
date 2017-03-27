using System;

namespace Api.Contract
{
	public class JobCardDTO
	{
		public string Link{ get; set; }

		public string Job{ get; set; }

		public string CompanyName{ get; set; }

		public string JobType{ get; set; }

		public string Location{ get; set; }

		public bool IsRemote{ get; set; }
	}

}

