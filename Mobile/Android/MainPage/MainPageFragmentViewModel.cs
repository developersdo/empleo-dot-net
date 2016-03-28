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

		[PreferredConstructor]
		public MainPageFragmentViewModel () : this(ServiceLocator.Current.GetInstance<INavigationService>())
		{
			
		}

		public MainPageFragmentViewModel (INavigationService navigationService)
		{
			_navigationService = navigationService;

			NavigateToFilterScreenCommand = new RelayCommand(OnNavigateToFilterScreen);
		}

		void OnNavigateToFilterScreen ()
		{
			_navigationService.NavigateTo(ScreenName.FilterLocationScreen);
		}
	}
}

