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

}