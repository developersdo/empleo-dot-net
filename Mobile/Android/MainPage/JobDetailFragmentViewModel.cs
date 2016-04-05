using System;
using Api.Contract;
using System.Threading.Tasks;

namespace Android
{
	public class JobDetailFragmentViewModel : ViewModelBase
	{
		IJobsApiService _jobsAPiService;

		public JobDetailFragmentViewModel (IJobsApiService jobsAPiService)
		{
			_jobsAPiService = jobsAPiService;
		}

		public async Task Init(string jobCardDTO)
		{
			if(string.IsNullOrEmpty(jobCardDTO))
				return;

			await ParseDTO(jobCardDTO);
		}

		async Task ParseDTO (string jobCardDTO)
		{
			var details = await _jobsAPiService.GetJobDetailForId(jobCardDTO);
		}
	}
}

