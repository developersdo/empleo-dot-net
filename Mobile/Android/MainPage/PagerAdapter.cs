using System;	
using Android.Runtime;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using V4PagerAdapter = Android.Support.V4.App.FragmentPagerAdapter;
using Android.Support.V4.App;
using Java.Lang;
using Android.Content.Res;

namespace Android.Activities
{
	public class MainPagerAdapter : V4PagerAdapter
	{
		IList<Fragment> _fragments;

		IList<ICharSequence> _titles;

		IList<IBackPressed>_backPressedListFragmet;

		Resources _resources;

		public override int Count
		{
			get 
			{
				return _fragments.Count;
			}
		}

		public MainPagerAdapter (FragmentManager fm, Resources resources) : base(fm)
		{
			_resources = resources;

			_fragments = new List<Fragment> ();

			_backPressedListFragmet = new List<IBackPressed>();

			InitPages();
		}

		void InitPages ()
		{
			var jobsFragment = new JobsFragment ();

			var categoriesFragment = new CategoriesFragment();

			var favoritesFragment = new FavoritesFragment();

			_fragments.Add (jobsFragment);

			_backPressedListFragmet.Add(jobsFragment);

			_fragments.Add (categoriesFragment);

			_backPressedListFragmet.Add(categoriesFragment);

//			_fragments.Add (favoritesFragment);
//
//			_backPressedListFragmet.Add(favoritesFragment);

			var pagesTitle = _resources.GetStringArray(Resource.Array.HomeTitles);

			_titles = new List<ICharSequence> (CharSequence.ArrayFromStringArray(pagesTitle));
		}

		public override Fragment GetItem (int position)
		{
			return _fragments [position];
		}

		public IBackPressed GetFragment(int position)
		{
			return _backPressedListFragmet[position];
		}

		public override ICharSequence GetPageTitleFormatted (int position)
		{
			return  _titles [position]; 
		}
	}
}