using System;
using Android.ViewModels;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Android.Views;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Contract;

namespace Android
{
	public class JobsFragmentViewModel : ViewModelBase
	{
		public ObservableCollection<JobCardDTO> Jobs { get; private set; }

		public JobCardDTO SelectedJob { get; private set; }

		ObservableCollection<JobCardDTO> _lastUpdatedJobs;

		public RelayCommand<int> OnJobSelectedCommand;

		public event EventHandler OnJobSelectedEvent;

		public bool IsLoading { get; set; }

		public bool QueryNotFound { get; set; }

		IJobsApiService _jobsAPiService;

		public JobsFragmentViewModel(IJobsApiService jobsAPiService)
		{
			_jobsAPiService = jobsAPiService;

			Jobs = new ObservableCollection<JobCardDTO>();

			OnJobSelectedCommand = new RelayCommand<int>(OnJobSelected);

			IsLoading = false;

			SubscribeToMessages();
		}

		void OnJobSelected (int position)
		{
			SelectedJob = Jobs.ElementAtOrDefault(position);

			OnJobSelectedEvent(this, null);
		}

		void SubscribeToMessages ()
		{
			MessengerInstance.Register<NotifyJobListUserChangedQuery>(this, OnUserSearch);
			MessengerInstance.Register<NotifyUserClearedText>(this, OnUserClearedText);
		}

		void OnUserClearedText (NotifyUserClearedText pr)
		{
			RemoveAnyState();

			AddToJobs(_lastUpdatedJobs, true);
		}

		async void OnUserSearch(NotifyJobListUserChangedQuery qr)
		{
			var query = qr.Query;

			if(string.IsNullOrEmpty(query))
				return;

			Jobs.Clear();

			ShowLoadingState();

			await Task.Delay(2000);

			ShowEmptyState();
		}

		void ShowEmptyState()
		{
			IsLoading = false;

			QueryNotFound = true;
		}

		void ShowLoadingState()
		{
			IsLoading = true;

			QueryNotFound = false;
		}

		void RemoveAnyState ()
		{
			IsLoading = false;

			QueryNotFound = false;
		}

		public override async void OnCreate()
		{
			if(!Jobs.Any())
			{
				await GetMostRecentJobs();
			}
		}

		async Task GetMostRecentJobs ()
		{
			IsLoading = true;

			var list = await _jobsAPiService.GetCardJobs();

			if(list != null && (list.Jobs != null && list.Jobs.Any()))
			{
				_lastUpdatedJobs = new ObservableCollection<JobCardDTO>(list.Jobs);

				AddToJobs(_lastUpdatedJobs);
			}
		}

		void AddToJobs(IEnumerable<JobCardDTO> recentJobs, bool clear = false)
		{
			if(clear)
				Jobs.Clear();
			
			foreach(var item in recentJobs)
			{
				Jobs.Add(item);
			}

			IsLoading = false;
		}

		public override void OnStop ()
		{
		}

		public override void OnResume ()
		{
			
		}

		protected virtual void OnOnJobSelectedEvent (EventArgs e)
		{
			var handler = OnJobSelectedEvent;
			if (handler != null)
				handler (this, e);
		}
	}
}

