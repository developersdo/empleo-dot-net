using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Graphics;
using Android.Activities;
using Android.Support.V4.App;
using Android.Content.Res;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Helpers;

namespace Android
{
	public class ViewPagerFragment : Fragment
	{
		TabLayout _tabLayout;

		ViewPager _viewPager;

		MainPagerAdapter _adapter;

		ViewPagerFragmentViewModel _viewModel;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			if(savedInstanceState == null)
			{
				GetDependencies();

				_viewModel.OnCreate();
			}
		}

		void GetDependencies ()
		{
			_viewModel = ServiceLocator.Current.GetInstance<ViewPagerFragmentViewModel>();
		}

		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);

			_viewModel.SwipeToTabEvent += OnSwipeToTab;
		}

		void OnSwipeToTab (object sender, SwipeToTabEventHandler e)
		{
			switch(e.Tab)
			{
				case Tab.JobSearch:
				{
					_viewPager.SetCurrentItem(0, true);
				}
				break;

			default:

				break;
			}
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

			var view = inflater.Inflate(Resource.Layout.HomePageViewPagerLayout, container, false);

			_viewPager = view.FindViewById<ViewPager>(Resource.Id.MainViewPager);

			_tabLayout = view.FindViewById<TabLayout>(Resource.Id.MainPageTabLayout);

			return view;
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			SetupViewPager();
		}

		void SetupViewPager ()
		{
			_adapter = new MainPagerAdapter (ChildFragmentManager, Resources);

			_viewPager.Adapter = _adapter;

			_viewPager.PageScrolled += OnPageScrolled;

			_tabLayout.TabGravity = TabLayout.GravityFill;

			_tabLayout.SetupWithViewPager(_viewPager);
		}

		public bool OnBackPressed()
		{	
			IBackPressed currentFragment = (IBackPressed) _adapter.GetFragment(_viewPager.CurrentItem);

			if (currentFragment != null) {
			
				return currentFragment.OnBackPressed();
			}

			return false;
		}

		void OnPageScrolled (object sender, ViewPager.PageScrolledEventArgs e)
		{
			_viewModel.PageScrolledCommand.Execute(e.Position);
		}
	}
}