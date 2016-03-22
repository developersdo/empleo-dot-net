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
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Graphics;

namespace Android
{
	[Activity (Label = "@string/SearchActivityTitle",Theme="@style/SearchScreenTheme")]
	public class SearchActivity : AppCompatActivity
	{
		Android.Support.V7.Widget.Toolbar _toolBar;

		SearchView _searchView;

		View _searchLayout;

		ListView _listView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.SearchActivityLayout);

			SetViewReferences();

			SetUpScreen ();
		}

		void SetViewReferences ()
		{
			_searchView = FindViewById<SearchView> (Resource.Id.MainSearchView);

			_searchLayout = FindViewById (Resource.Id.MainSearchLayout);

			_toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.MainToolbar);

			_listView = FindViewById<ListView>(Resource.Id.resultList);

			_listView.Adapter = new SearchLocationAdapter(this);
		}

		void SetUpScreen()
		{
			SetSupportActionBar(_toolBar);

			Title = GetString(Resource.String.MainPage);

			_searchLayout.Click += OnSearchLayoutSelected;

			_searchView.QueryTextSubmit += OnQueryTextSubmit;

			_searchView.SetIconifiedByDefault(false);

			_searchView.SetQueryHint(GetString(Resource.String.SearchPageSearchBarHint));

			PersonalizeSearchView();
		}

		void OnQueryTextSubmit (object sender, SearchView.QueryTextSubmitEventArgs e)
		{
			
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
	}
}