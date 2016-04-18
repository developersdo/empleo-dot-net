using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Graphics;
using Android.Support.V4.App;
using Android.App;
using Android.Activities;
using Android.Gms.Location.Places.UI;
using Microsoft.Practices.ServiceLocation;
using Praeclarum.Bind;
using GalaSoft.MvvmLight.Helpers;

namespace Android
{
	[Activity (Theme="@style/AppTheme", Label = "@string/SearchActivityTitle",ParentActivity = typeof(MainPageActivity))]
	public class SearchActivity : AppCompatActivityBase
	{
		TextView _address;

		V7Toolbar _toolBar;

		PlaceAutocompleteFragment _autocompleteFragment;

		ViewGroup _searchLayout;

		ListView _listView;

		IList<Binding<string, string> > _bindings;

		public SearchViewModel _viewModel { get; set; }

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.SearchActivityLayout);

			GetDependencies();

			GetViewReferences();

			_viewModel.OnCreate();

			SetupScreen();

			SetBindings();
		}

		void GetDependencies ()
		{
			_viewModel = ServiceLocator.Current.GetInstance<SearchViewModel>();
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

		void SetBindings ()
		{
			_bindings = new List<Binding<string, string>>();

			_bindings.Add(this.SetBinding (() => _viewModel.Address, _address, () => _address.Text, BindingMode.OneWay));

		}

		void GetViewReferences ()
		{
			_autocompleteFragment = (PlaceAutocompleteFragment)
				FragmentManager.FindFragmentById(Resource.Id.place_autocomplete_fragment);
			
			_searchLayout = FindViewById<ViewGroup>(Resource.Id.MainSearchViewParent);

			_toolBar = FindViewById<V7Toolbar>(Resource.Id.MainToolbar);

			_listView = FindViewById<ListView>(Resource.Id.resultList);

			_address = FindViewById<TextView> (Resource.Id.Address);
		}

		public void SetupScreen()
		{
			SetSupportActionBar(_toolBar);

			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			_listView.Adapter = _viewModel.RecentSearch.GetAdapter(OnRecentSearch);

			_searchLayout.Click += OnSearchLayoutSelected;

			_autocompleteFragment.PlaceSelected += OnPlaceSelected;

			_autocompleteFragment.SetHint(GetString(Resource.String.SearchPageSearchBarHint));

			PersonalizeSearchView();
		}

		View OnRecentSearch (int position, SearchResultItem data, View view)
		{
			var convertView = view ?? LayoutInflater.FromContext(this).Inflate(Resource.Layout.SearchItemCard, null);

			var city = convertView.FindViewById<TextView>(Resource.Id.city);

			var address = convertView.FindViewById<TextView>(Resource.Id.address);

			city.Text = data.City;

			address.Text = data.Address;

			return convertView;
		}

		void OnQueryTextSubmit (object sender, SearchView.QueryTextSubmitEventArgs e)
		{
			
		}

		void OnPlaceSelected (object sender, PlaceSelectedEventArgs e)
		{
			
		}

		void PersonalizeSearchView ()
		{
//			var ll = (LinearLayout)_searchView.GetChildAt(0);  
//
//			var ll2 = (LinearLayout)ll.GetChildAt(2);  
//
//			var ll3 = (LinearLayout)ll2.GetChildAt(1);  
//
//			var p = (EditText)ll3.GetChildAt(0);
//
//			p.SetHintTextColor(Color.LightGray);
		}

		void OnSearchLayoutSelected(object sender, EventArgs e)
		{
//			_searchView.RequestFocus();
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();

			foreach(var bind in _bindings)
				bind.Detach();
		}
	}
}