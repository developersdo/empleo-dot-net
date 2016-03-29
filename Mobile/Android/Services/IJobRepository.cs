using System;
using System.Collections.ObjectModel;
using Android.ViewModels;
using System.Threading.Tasks;
using System.Linq;

namespace Android
{
	public interface IJobRepository
	{
		Task<ObservableCollection<JobItemViewModel>> FindJobByTitle(string query);

		Task<ObservableCollection<JobItemViewModel>> GetMostRecentJobs(int limit = 20);
	}

	public class JobRepository : IJobRepository
	{
		ObservableCollection<JobItemViewModel> _jobs;

		public JobRepository ()
		{
			_jobs = new ObservableCollection<JobItemViewModel> {
				new JobItemViewModel {
					Title = "Junior Mobile Developer",
					IsRemote = true,
					CompanyName = "Megsoft Consulting",
					Location = "Santo Domingo",
					Category = "Software"
				},
				new JobItemViewModel {
					Title = "Senior Mobile Developer",
					IsRemote = true,
					Location = "New York",
					CompanyName = "Pepe Consulting",
					Category = "Software"
				},
				new JobItemViewModel {
					Title = "Abuelo Web Developer",
					IsRemote = true,
					Location = "Egipto",
					CompanyName = "Raul Consulting",
					Category = "Software"
				},
				new JobItemViewModel {
					Title = ".Net Developer",
					IsRemote = false,
					CompanyName = "PHd Consulting",
					Location = "Santiago",
					Category = "Software"
				}
			};
		}

		public async Task<ObservableCollection<JobItemViewModel>> FindJobByTitle (string query)
		{
			await Task.Delay(2000);

			return _jobs;
		}

		public async Task<ObservableCollection<JobItemViewModel>> GetMostRecentJobs (int limit = 20)
		{
			await Task.Delay(2000);

			return _jobs;
		}

	}
}