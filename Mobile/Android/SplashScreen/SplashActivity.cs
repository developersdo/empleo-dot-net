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
using System.Threading.Tasks;
using Empleado;
using Microsoft.Practices.ServiceLocation;

namespace Android
{
	[Activity (Label = "@string/ApplicationName",MainLauncher = true, NoHistory = true, Theme="@style/AppTheme")]			
	public class SplashActivity : AppCompatActivityBase
	{
		SplashViewModel _viewModel;

		protected override async void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.SplashScreenLayout);

			SetupScreen();

			await Run();

			GetServices();

			NavigateTo();
		}

		void SetupScreen ()
		{
			Window.AddFlags(WindowManagerFlags.Fullscreen);
		}

		async Task Run ()
		{
			await Task.Run(async()=>{
				
				new Bootstrapping();

				await Task.Delay(1000);
			});
		}

		void GetServices ()
		{
			_viewModel = ServiceLocator.Current.GetInstance<SplashViewModel> ();
		}

		void NavigateTo ()
		{
			RunOnUiThread(()=>{
				_viewModel.Init();
			});
		}
	}
}