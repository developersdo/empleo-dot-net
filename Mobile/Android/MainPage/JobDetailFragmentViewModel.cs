using System;
using Core;
using Api.Contract;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace Android
{
	public class JobDetailFragmentViewModel : ViewModelBase
	{
		IJobsApiService _jobsAPiService;

		IEmailService _applicationSender;

		public string CompanyName { get; set; }

		public string JobTitle { get; set; }

		public string JobType { get; set; }

		public string JobDescription { get; set; }

		public bool IsRemote { get; set; }

		public string Location { get; set; }

		public string Visits { get; set; }

		public string CompanyEmail { get; set; }

		public RelayCommand SendCVCommand { get; set; }

		public JobDetailFragmentViewModel (IJobsApiService jobsAPiService, IEmailService applicationSender)
		{
			_jobsAPiService = jobsAPiService;

			_applicationSender = applicationSender;

			SendCVCommand = new RelayCommand (SendCV);
		}

		void SendCV(){
			_applicationSender.SendEmail (CompanyEmail, JobTitle);
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

			IsRemote = details.IsRemote;

			Location = details.Location;

			JobDescription = details.JobDescription;

			JobTitle = details.JobTitle;

			JobType = details.JobType;

			CompanyEmail = details.CompanyEmail;

			CompanyName = details.CompanyName;

			Visits = details.Visits.ToString();
		}
	}
}
