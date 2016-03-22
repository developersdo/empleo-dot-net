using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Android
{
	public class CategoriesFragment : Fragment
	{
		ListView _listview;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var layout = inflater.Inflate(Resource.Layout.CategoriesFragmentLayout, container, false);

			_listview = layout.FindViewById<ListView> (Resource.Id.categoriesFragment);

			return layout;
		}

		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);

			_listview.Adapter = new CategoriesFragmentAdapter(this.Activity);
		}
	}
}