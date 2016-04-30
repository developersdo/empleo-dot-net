using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Support.V4.App;
using Android.App;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Messaging;
using Android.Support.V4.View;
using Android.Views.InputMethods;
using Core;

namespace Android
{
	public class MainPageFragment : Android.Support.V4.App.Fragment
	{
		View _searchLayout;

		SearchView _searchView;

//		LinearLayout _locationContainer;

		ViewPagerFragment _viewPagerFragment;

		MainPageFragmentViewModel _viewModel;

		IMessenger _messenger;

		IKeyboardService _keyboardService;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			GetServices();

			RegisterMessages();

			Init();
		}

		void RegisterMessages ()
		{
			_messenger.Register<NotifySearchBarPutText>(this, OnTextReceived);
		}

		void OnTextReceived (NotifySearchBarPutText model)
		{
			_searchView.SetQuery(model.Query, true);
		}

		void GetServices ()
		{
			_viewModel = ServiceLocator.Current.GetInstance<MainPageFragmentViewModel>();

			_keyboardService = ServiceLocator.Current.GetInstance<IKeyboardService>();

			_messenger = GalaSoft.MvvmLight.Messaging.Messenger.Default;
		}

		void Init ()
		{
			_viewPagerFragment = new ViewPagerFragment();

			ChildFragmentManager
				.BeginTransaction()
				.Replace(Resource.Id.container, _viewPagerFragment)
				.Commit();
		}

		void SetUpScreen()
		{
			_searchLayout.Click += OnSearchLayoutSelected;

			_searchView.QueryTextSubmit += OnQuerySubmit;

			_searchView.QueryTextChange += OnQueryTextChanged;

			_searchView.Focusable = true;

			_searchView.RequestFocusFromTouch();

			_searchView.ClearFocus();

			_searchView.SetIconifiedByDefault(false);

			_searchView.SetQueryHint(GetString(Resource.String.HomePageSearchBarHint));

			PersonalizeSearchView();
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			SetUpScreen();
		}

		void PersonalizeSearchView ()
		{
			var ll = (LinearLayout)_searchView.GetChildAt(0);  

			var ll2 = (LinearLayout)ll.GetChildAt(2);  

			var ll3 = (LinearLayout)ll2.GetChildAt(1);  

			var p = (EditText)ll3.GetChildAt(0);

			p.SetHintTextColor(Color.LightGray);
		}

		void SetBindings ()
		{
//			_locationContainer.SetCommand("Click", _viewModel.NavigateToFilterScreenCommand);
		}

		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);

			SetBindings();
		}

		void OnSearchLayoutSelected(object sender, EventArgs e)
		{
			_searchView.SetIconifiedByDefault(false);

			_searchView.RequestFocusFromTouch();

			_keyboardService.ShowKeyboard(_searchView);
		}

		//I know this is wrong, but i will fix this later.
		// MvvmLight does not support EventHandler<T> binding
		//Binding library in the core project, does not support binding to event-to-command
		//So somehow i need to accomplish this task
		void OnQuerySubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
		{
			_viewModel.UserIsTypingCommand.Execute(_searchView.Query);
		}

		//I know this is wrong, but i will fix this later.
		// MvvmLight does not support EventHandler<T> binding
		//Binding library in the core project, does not support binding to event-to-command
		//So somehow i need to accomplish this task
		void OnQueryTextChanged (object sender, SearchView.QueryTextChangeEventArgs e)
		{
			if(string.IsNullOrEmpty(e.NewText))
			{
				_viewModel.UserClearedTextCommand.Execute(null);
			}
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.MainPageFragmentLayout, container, false);

			_searchLayout = view.FindViewById (Resource.Id.segueta);

//			_locationContainer = view.FindViewById<LinearLayout> (Resource.Id.locationContainer);

			_searchView = view.FindViewById<SearchView> (Resource.Id.MainSearchView);

			return view;
		}

		public bool OnBackPressed ()
		{
			return _viewPagerFragment.OnBackPressed();
		}
	}
}

