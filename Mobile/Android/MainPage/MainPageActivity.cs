using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.OS;
using View = Android.Views.View;
using Android.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Support.V7.View;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Graphics;

namespace Android.Activities
{
	[Activity (Theme="@style/AppTheme", Label="@string/MainPage")]
	public class MainPageActivity : AppCompatActivityBase
	{
		MainPageFragment _viewPagerFragment;

		V7Toolbar _toolBar;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.MainPageLayout);

			Init(savedInstanceState);

			SetViewReferences();

			SetSupportActionBar(_toolBar);
		}

		void SetViewReferences ()
		{
			_toolBar = FindViewById<V7Toolbar> (Resource.Id.MainToolbar);
		}

		void Init (Bundle savedInstanceState)
		{
			if (savedInstanceState == null) {
				
				SetupInnerFragment();

			} else {
				
				_viewPagerFragment = (MainPageFragment) SupportFragmentManager.Fragments[0];
			}
		}

		void SetupInnerFragment ()
		{
			_viewPagerFragment = new MainPageFragment();

			SupportFragmentManager
				.BeginTransaction()
				.Replace(Resource.Id.parent_container, _viewPagerFragment)
				.Commit();
		}

		public override void OnBackPressed ()
		{
			_viewPagerFragment.OnBackPressed();
		}
	}
}