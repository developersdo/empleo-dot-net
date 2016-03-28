using System;
using Android.Support.V7.App;
using Android.OS;
using Android.Support.V4.App;

namespace Android
{
	public class JobDetail : Fragment, IBackPressed
	{
		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.JobDetailActivityLayout, container, false);
		}

		public bool OnBackPressed ()
		{
			return new BackPressImpl(this).OnBackPressed();
		}
	}
}

