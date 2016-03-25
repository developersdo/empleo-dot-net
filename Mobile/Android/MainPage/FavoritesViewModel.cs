using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Android.ViewModels;

namespace Android
{
	public class FavoritesViewModel : ViewModelBase
	{
		public ObservableCollection<JobItemViewModel> People { get; private set; }

		public RelayCommand OnJobSelectedCommand;

		public event EventHandler OnJobSelectedEvent;

		public FavoritesViewModel ()
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

