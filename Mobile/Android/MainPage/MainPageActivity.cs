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
	[Activity (Theme="@style/AppTheme")]
	public class MainPageActivity : AppCompatActivityBase
	{
		ViewPagerFragment _viewPagerFragment;

		V7Toolbar _toolBar;

		SearchView _searchView;

		View _searchLayout;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.MainPageLayout);

			Init(savedInstanceState);

			SetViewReferences();

			SetUpScreen ();
		}

		void SetUpScreen()
		{
			Title = GetString(Resource.String.MainPage);

			SetSupportActionBar(_toolBar);

			_searchLayout.Click += OnSearchLayoutSelected;

			_searchView.QueryTextSubmit += OnQueryTextSubmit;

			_searchView.SetIconifiedByDefault(false);

			_searchView.SetQueryHint(GetString(Resource.String.HomePageSearchBarHint));

			PersonalizeSearchView();
		}

		void PersonalizeSearchView ()
		{
			var ll = (LinearLayout)_searchView.GetChildAt(0);  

			var ll2 = (LinearLayout)ll.GetChildAt(2);  

			var ll3 = (LinearLayout)ll2.GetChildAt(1);  

			var p = (EditText)ll3.GetChildAt(0);

			p.SetHintTextColor(Color.LightGray);
		}

		void OnSearchLayoutSelected(object sender, EventArgs e)
		{
			_searchView.RequestFocus();
		}

		void OnQueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e){
			
		}

		void SetViewReferences ()
		{
			_toolBar = FindViewById<V7Toolbar>(Resource.Id.MainToolbar);

			_searchView = FindViewById<SearchView> (Resource.Id.MainSearchView);

			_searchLayout = FindViewById (Resource.Id.MainSearchLayout);
		}

		void Init (Bundle savedInstanceState)
		{
			if (savedInstanceState == null) {
				
				SetupInnerFragment();

			} else {
				
				_viewPagerFragment = (ViewPagerFragment) SupportFragmentManager.Fragments[0];
			}
		}

		void SetupInnerFragment ()
		{
			_viewPagerFragment = new ViewPagerFragment();

			SupportFragmentManager
				.BeginTransaction()
				.Replace(Resource.Id.container, _viewPagerFragment)
				.Commit();
		}

		public override void OnBackPressed ()
		{
			if (!_viewPagerFragment.OnBackPressed()) {
				base.OnBackPressed();
			}
		}
	}
}