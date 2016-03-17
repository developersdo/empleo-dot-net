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

			InitPages();
		}

		void InitPages ()
		{
			_fragments.Add (new JobsFragment ());

			_fragments.Add (new CategoriesFragment ());

			_fragments.Add (new FavoritesFragment ());

			var pagesTitle = _resources.GetStringArray(Resource.Array.HomeTitles);

			_titles = new List<ICharSequence> (CharSequence.ArrayFromStringArray(pagesTitle));
		}

		public override Fragment GetItem (int position)
		{
			return _fragments [position];
		}

		public override ICharSequence GetPageTitleFormatted (int position)
		{
			return  _titles [position]; 
		}
	}
}

