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
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Activities;
using Microsoft.Practices.ServiceLocation;
using com.refractored;
using Praeclarum.Bind;
using GalaSoft.MvvmLight.Helpers;

namespace Android
{
	[Activity(Theme="@style/LandingPageTheme")]
	public class LandingPageActivity : AppCompatActivityBase
	{
		Android.Support.V7.Widget.Toolbar _toolbar;

		ViewPager _pager;

		PagerSlidingTabStrip _tabs;

		Button _startAppButton;

		LandingPageViewModel _viewModel;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.LandingPageLayout);

			GetServices();

			GetViewReferences();

			SetUpActionBar();

			SetFullScreen();

			SetUpPager();
		}

		protected override void OnStart ()
		{
			base.OnStart ();

			_startAppButton.SetCommand("Click", _viewModel.NavigateToHomeScreenCommand);
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			_viewModel.OnResume();
		}

		protected override void OnStop ()
		{
			base.OnStop ();

			_viewModel.OnStop();
		}

		void GetServices ()
		{
			_viewModel = ServiceLocator.Current.GetInstance<LandingPageViewModel>();
		}

		void GetViewReferences ()
		{
			_toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);

			_pager = FindViewById<ViewPager> (Resource.Id.pager);

			_tabs = FindViewById<PagerSlidingTabStrip> (Resource.Id.tabs);

			_startAppButton = FindViewById<Button>(Resource.Id.done);
		}

		void SetUpActionBar ()
		{
			if(ActionBar != null)
			{
				if (_toolbar != null) {

					SetSupportActionBar(_toolbar);

					SupportActionBar.SetDisplayHomeAsUpEnabled(false);
				
					SupportActionBar.SetHomeButtonEnabled (false);
				}
			}
		}

		void SetFullScreen ()
		{
			this.Window.AddFlags(WindowManagerFlags.Fullscreen);
		}

		void SetUpPager ()
		{
			_pager.Adapter = new LandingPagerAdapter(SupportFragmentManager, this);

			_tabs.SetViewPager(_pager);
		}
	}
}

