using System;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using Android.Activities;
using GalaSoft.MvvmLight;
using Android;

namespace Empleado
{
	public class Bootstrapping
	{
		public bool IsInitialized { get { return ServiceLocator.IsLocationProviderSet; } }

		public Bootstrapping ()
		{
			Init();

			RegisterViewModels();
		}

		void Init ()
		{
			if (!IsInitialized)
			{
				ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

				var nav = new AppCompatNavigationService();

				nav.Configure(ScreenName.LandingPage, typeof(LandingPageActivity));

				nav.Configure(ScreenName.MainPage, typeof(MainPageActivity));

				SimpleIoc.Default.Register<INavigationService>(() => nav);
			}
		}

		void Run ()
		{
			if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
			{

			}
			else
			{

			}
		}

		void RegisterViewModels ()
		{
			SimpleIoc.Default.Register<LandingPageViewModel, LandingPageViewModel>();
			SimpleIoc.Default.Register<SplashViewModel,SplashViewModel>();
			SimpleIoc.Default.Register<JobsFragmentViewModel,JobsFragmentViewModel>();
			SimpleIoc.Default.Register<FavoritesViewModel,FavoritesViewModel>();
		}
	}
}

