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
using GalaSoft.MvvmLight.Messaging;
using Android.Content.PM;
using Microsoft.Practices.ServiceLocation;
using Android.Runtime;

namespace Android.Activities
{
	[Activity (Theme="@style/AppTheme", Label="@string/MainPage")]
	public class MainPageActivity : AppCompatActivityBase
	{
		MainPageFragment _viewPagerFragment;

		V7Toolbar _toolBar;

		MainPageActivityViewModel _viewModel;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.MainPageLayout);

			GetDependencies();

			Init(savedInstanceState);

			SetViewReferences();

			SetSupportActionBar(_toolBar);

			SubscribeToEvents();

			_viewModel.OnCreate();
		}

		void GetDependencies ()
		{
			_viewModel = ServiceLocator.Current.GetInstance<MainPageActivityViewModel>();
		}

		void SubscribeToEvents ()
		{
			_viewModel.PropertyChanged += OnPropertyChanged;
		}

		public override bool OnPrepareOptionsMenu (Android.Views.IMenu menu)
		{
			menu.Clear();

			var items = _viewModel.OptionsMenu;

			foreach(var item in items)
			{
				menu
					.Add(0,
					item.Id,
					0,
					new Java.Lang.String(item.Text));

				var menuItem = menu.FindItem(item.Id);

				switch(item.ShowAs)
				{
				case ShowAs.Hidden:
					{
						menuItem.SetShowAsAction(Android.Views.ShowAsAction.Never);
					}
					break;
				case ShowAs.Visible:
					{
						menuItem.SetShowAsAction(Android.Views.ShowAsAction.IfRoom);
					}
					break;
				default: 
					break;
				}
			}

			return base.OnPrepareOptionsMenu(menu);
		}

		void OnPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
				case "OptionsMenu":
				{
					InvalidateOptionsMenu();
				}
				break;
			}
		}

		public override bool OnOptionsItemSelected (Android.Views.IMenuItem item)
		{
			switch(item.ItemId)
			{
			case 1:
				{
					_viewModel.OptionMenuSelectedCommand.Execute(item.ItemId);
				}
				return true;
			default: 
				return false;
			}
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