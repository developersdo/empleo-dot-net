using System;
using PropertyChanged;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Android
{
	public class LandingPageViewModel : ViewModelBase
	{
		INavigationService _navigationService;

		public string Title { get; set; }

		public RelayCommand NavigateToHomeScreenCommand { get; set; }

		public LandingPageViewModel (INavigationService navigationService)
		{
			_navigationService = navigationService;

			NavigateToHomeScreenCommand = new RelayCommand(OnNavigateToHomeScreenCommand);
		}

		void OnNavigateToHomeScreenCommand ()
		{
			_navigationService.NavigateTo(ScreenName.MainPage);
		}

		public void OnResume()
		{
			
		}

		public void OnStop()
		{
			
		}
	}
}