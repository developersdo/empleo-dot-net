using System;
using Android.Support.V7.App;
using Android.App;
using Android.OS;

namespace Android
{
	[Activity(Theme="@style/AppTheme")]
	public class JobDetailActivity : AppCompatActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.JobDetailActivityLayout);
		}
	}
}

