using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace Android
{	
	public class SplashViewModel : ViewModelBase
	{
		INavigationService _navigationService;

		public SplashViewModel (INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public void Init()
		{
			_navigationService.NavigateTo(ScreenName.LandingPage);
		}
	}
}

