
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
using Android.Support.V7.App;

namespace Android
{
	public class AppCompatActivityBase : AppCompatActivity
	{
		public static AppCompatActivityBase CurrentActivity { get; private set; }

		internal string ActivityKey { get; private set; }

		internal static string NextPageKey { get; set; }

		public static void GoBack()
		{
			CurrentActivity?.OnBackPressed();
		}

		protected override void OnResume()
		{
			CurrentActivity = this;
			if (string.IsNullOrEmpty(ActivityKey))
			{
				ActivityKey = NextPageKey;
				NextPageKey = null;
			}
			base.OnResume();
		}
	}
}

