using System;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using Core;

namespace Android
{
	public class MainPageFragmentViewModel : ViewModelBase
	{
		public RelayCommand NavigateToFilterScreenCommand { get; set; }

		INavigationService _navigationService;

		public string SearchText { get; set; }

		public RelayCommand UserClearedTextCommand { get; set; }

		public RelayCommand<string> UserIsTypingCommand { get; set; }

		IGithubContributorService githubContributors;

		public MainPageFragmentViewModel (INavigationService navigationService, 
			IGithubContributorService githubContributors)
		{
			this.githubContributors = githubContributors;
			_navigationService = navigationService;

			UserIsTypingCommand = new RelayCommand<string>(OnUserSubmitText);

			UserClearedTextCommand = new RelayCommand(OnUserClearedText);

			NavigateToFilterScreenCommand = new RelayCommand(OnNavigateToFilterScreen);
		}

		void OnUserClearedText ()
		{
			MessengerInstance.Send<NotifyUserClearedText>(null);
		}

		void OnUserSubmitText (string parameter)
		{
			MessengerInstance.Send<NotifyUserChangedQuery>(new NotifyUserChangedQuery
				{
					Query = parameter
				});
		}

		void OnNavigateToFilterScreen ()
		{
			_navigationService.NavigateTo(ScreenName.FilterLocationScreen);
		}
	}
}

