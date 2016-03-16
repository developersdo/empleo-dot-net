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
using com.refractored;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Util;

namespace Android
{
	[Activity(MainLauncher = true,Theme="@style/AppBaseTheme")]
	public class LandingPageActivity : AppCompatActivity
	{
		Android.Support.V7.Widget.Toolbar _toolbar;

		ViewPager _pager;

		PagerSlidingTabStrip _tabs;

		Button _startAppButton;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.LandingPageLayout);

			GetViewReferences();

			SetUpActionBar();

			SetFullScreen();

			SetUpPager();
		}

		protected override void OnStart ()
		{
			base.OnStart ();

			_startAppButton.Click += OnStartAppSelected;
		}

		protected override void OnStop ()
		{
			base.OnStop ();

			_startAppButton.Click -= OnStartAppSelected;
		}

		void GetViewReferences ()
		{
			_toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);

			_pager = FindViewById<ViewPager> (Resource.Id.pager);

			_tabs = FindViewById<PagerSlidingTabStrip> (Resource.Id.tabs);

			_startAppButton = FindViewById<Button>(Resource.Id.done);
		}

		void OnStartAppSelected (object sender, EventArgs e)
		{
			
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

