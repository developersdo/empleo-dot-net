using System;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;

namespace Android
{
	public class MainPageFragmentViewModel : ViewModelBase
	{
		public RelayCommand NavigateToFilterScreenCommand { get; set; }

		INavigationService _navigationService;

		public string SearchText { get; set; }

		public RelayCommand UserClearedTextCommand { get; set; }

		public RelayCommand<string> UserIsTypingCommand { get; set; }

		[PreferredConstructor]
		public MainPageFragmentViewModel () : this(ServiceLocator.Current.GetInstance<INavigationService>())
		{
			UserIsTypingCommand = new RelayCommand<string>(OnUserIsTyping);

			UserClearedTextCommand = new RelayCommand(OnUserClearedText);
		}

		public MainPageFragmentViewModel (INavigationService navigationService)
		{
			_navigationService = navigationService;

			NavigateToFilterScreenCommand = new RelayCommand(OnNavigateToFilterScreen);
		}

		void OnUserClearedText ()
		{
			MessengerInstance.Send<NotifyUserClearedText>(null);
		}

		void OnUserIsTyping (string parameter)
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

