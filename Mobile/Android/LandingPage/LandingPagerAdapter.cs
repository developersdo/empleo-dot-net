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
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Support.V7.App;

namespace Android
{
	public class LandingPagerAdapter : FragmentPagerAdapter
	{
		IList<LandingPageFragment> _pages;

		AppCompatActivity _activity;

		public override int Count {
			get {
				return _pages.Count;
			}
		}

		public LandingPagerAdapter (Android.Support.V4.App.FragmentManager fm, AppCompatActivity activity) : base(fm)
		{
			_activity = activity;

			Init();
		}

		void Init ()
		{
			_pages = new List<LandingPageFragment>
			{
				new LandingPageFragment
				{
					LandingPageInfo = new LandingPageInfo
					{
						Description = Resource.String.first_page_description,
						Icon = Resource.Drawable.person,
						Title = Resource.String.first_page_title
					}
				},
				new LandingPageFragment
				{
					LandingPageInfo = new LandingPageInfo
					{
						Description = Resource.String.second_page_description,
						Icon = Resource.Drawable.pizza,
						Title = Resource.String.second_page_title
					}
				},
				new LandingPageFragment
				{
					LandingPageInfo = new LandingPageInfo
					{
						Description = Resource.String.third_page_description,
						Icon = Resource.Drawable.remote,
						Title = Resource.String.third_page_title
					}
				}
			};
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted (int position)
		{
			return new Java.Lang.String(string.Empty);
		}

		public override Android.Support.V4.App.Fragment GetItem (int position)
		{
			var fragment = _pages[position];

			if(fragment != null)
				return fragment;
			else
				return new Android.Support.V4.App.Fragment();
		}
	}
}

