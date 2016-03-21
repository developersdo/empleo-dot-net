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
	public class JobsFragment : Fragment
	{
		ListView _listView;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);
		
			SetUp ();
		}

		void SetUp()
		{
			_listView = Activity.FindViewById<ListView> (Resource.Id.JobsListView);

			_listView.Adapter = new JobListAdapter (Activity);

			_listView.ItemClick += OnListItemClick;
		}

		void OnListItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			//TODO: Navigation stuff
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.JobsFragmentLayout, container, false);
		}
	}
}

