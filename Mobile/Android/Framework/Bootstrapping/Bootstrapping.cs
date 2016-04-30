using System;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using Android.Activities;
using GalaSoft.MvvmLight;
using Android;
using Android.Graphics;
using Core;
using Api.Contract;
using Api;
using APIs;
using Android.Views.InputMethods;
using Xamarin;
using Android.Content;

namespace Empleado
{
	public class Bootstrapping
	{
		public bool IsInitialized { get { return ServiceLocator.IsLocationProviderSet; } }

		public Bootstrapping ()
		{
			Init();

			RegisterViewModels();

			InitXamarinInsight
				( ServiceLocator.Current.GetInstance<IContextService>()
				, ServiceLocator.Current.GetInstance<IMobileConfigurationManager>());
		}

		void Init ()
		{
			if (!IsInitialized)
			{
				ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

				var nav = new AppCompatNavigationService();

				nav.Configure(ScreenName.LandingPage, typeof(LandingPageActivity));

				nav.Configure(ScreenName.MainPage, typeof(MainPageActivity));

				nav.Configure(ScreenName.FilterLocationScreen, typeof(SearchActivity));

				nav.Configure(ScreenName.AboutScreen, typeof(AboutActivity));

				SimpleIoc.Default.Register<INavigationService>(() => nav);

				Run();
			}
		}

		void Run ()
		{
			if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
			{

			}
			else
			{
				SimpleIoc.Default.Register<IProxy, HttpProxy>();
				SimpleIoc.Default.Register<IAssetReader, AssetReader>();
				SimpleIoc.Default.Register<IMobileConfigurationManager, MobileConfigurationManager>();
				SimpleIoc.Default.Register<IJobRepository, JobRepository>();
				SimpleIoc.Default.Register<IBitmapResizer<Bitmap>, BitmapResizer>();
				SimpleIoc.Default.Register<IGeolocationService, GeolocationService>();
				SimpleIoc.Default.Register<IXMLStorage, XMLStorage>();
				SimpleIoc.Default.Register<IAppInfoService, AppInfoService>();
				SimpleIoc.Default.Register<ILanguageService, LanguageService>();
				SimpleIoc.Default.Register<IContextService,ContextService>();
				SimpleIoc.Default.Register<IJobsApiService, FakeJobsApiService>();
				SimpleIoc.Default.Register<IGithubContributorService, OctocatContributorService>();
				SimpleIoc.Default.Register<IEmailService, EmailService> ();
				SimpleIoc.Default.Register<IKeyboardService, KeyboardService>();
			}
		}

		void RegisterViewModels ()
		{
			SimpleIoc.Default.Register<LandingPageViewModel, LandingPageViewModel>();
			SimpleIoc.Default.Register<SplashViewModel,SplashViewModel>();
			SimpleIoc.Default.Register<JobsFragmentViewModel,JobsFragmentViewModel>();
			SimpleIoc.Default.Register<FavoritesViewModel,FavoritesViewModel>();
			SimpleIoc.Default.Register<MainPageFragmentViewModel,MainPageFragmentViewModel>();
			SimpleIoc.Default.Register<CategoriesFragmentViewModel,CategoriesFragmentViewModel>();
			SimpleIoc.Default.Register<ViewPagerFragmentViewModel,ViewPagerFragmentViewModel>();
			SimpleIoc.Default.Register<SearchViewModel,SearchViewModel>();
			SimpleIoc.Default.Register<JobDetailFragmentViewModel,JobDetailFragmentViewModel>();
			SimpleIoc.Default.Register<MainPageActivityViewModel,MainPageActivityViewModel>();
			SimpleIoc.Default.Register<AboutViewModel,AboutViewModel>();
		}

		void InitXamarinInsight (IContextService contextService, IMobileConfigurationManager configService)
		{
			Insights.Initialize(configService.MobileConfigurationFile.XamarinInsightKey, ((Context)contextService.GetContext()));

			Insights.HasPendingCrashReport += async(sender, isStartupCrash) =>
			{
				if (isStartupCrash)
				{
					await Insights.PurgePendingCrashReports();
				}
			};
		}
	}
}

