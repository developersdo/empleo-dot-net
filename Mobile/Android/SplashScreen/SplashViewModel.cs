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
using System.Threading.Tasks;

namespace Android
{
	public class SplashViewModel : ViewModelBase
	{
		INavigationService _navigationService;

		IAppInfoService _infoService;

		IXMLStorage _xmlStorage;

		public SplashViewModel 
			(INavigationService navigationService,
			IAppInfoService infoService,
			IXMLStorage xmlStorage)
		{
			_xmlStorage = xmlStorage;

			_infoService = infoService;

			_navigationService = navigationService;
		}

		public async Task Init()
		{
			var version = _infoService.CodeVersion;

			var pastVersion = await _xmlStorage.ReadStringAsync(Extras.WHICH_USER_OPEN_APP_VERSION);

			if(string.IsNullOrEmpty(pastVersion))
			{
				await _xmlStorage.SaveStringAsync(Extras.WHICH_USER_OPEN_APP_VERSION, version.ToString());

				_navigationService.NavigateTo(ScreenName.LandingPage);
			}
			else
			{
				_navigationService.NavigateTo(ScreenName.MainPage);
			}
		}
	}
}