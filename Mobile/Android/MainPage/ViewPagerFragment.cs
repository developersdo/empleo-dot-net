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

namespace Android
{
	public class ViewPagerFragment : Fragment
	{
		TabLayout _tabLayout;

		ViewPager _viewPager;

		MainPagerAdapter _adapter;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

			var view = inflater.Inflate(Resource.Layout.HomePageViewPagerLayout, container, false);

			_viewPager = view.FindViewById<ViewPager>(Resource.Id.MainViewPager);

			_tabLayout = view.FindViewById<TabLayout>(Resource.Id.MainPageTabLayout);

			return view;
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			_adapter = new MainPagerAdapter (ChildFragmentManager, Resources);

			_viewPager.Adapter = _adapter;

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
	}
}