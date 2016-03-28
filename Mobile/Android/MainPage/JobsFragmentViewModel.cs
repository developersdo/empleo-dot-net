using System;
using Android.ViewModels;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace Android
{
	public class JobsFragmentViewModel : ViewModelBase
	{
		public ObservableCollection<JobItemViewModel> People { get; private set; }

		public RelayCommand OnJobSelectedCommand;

		public event EventHandler OnJobSelectedEvent;

		public JobsFragmentViewModel ()
		{
			OnJobSelectedCommand = new RelayCommand(OnJobSelected);
		}

		void OnJobSelected ()
		{
			OnJobSelectedEvent(this, null);
		}

		public override void OnCreate()
		{
			People = new ObservableCollection<JobItemViewModel>
			{
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

