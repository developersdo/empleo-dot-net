using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Xamarin;

namespace Android
{
	[Application]
	public class EmpleadoApp : Application {

		public static Context AppContext { get; private set; }

		public EmpleadoApp (IntPtr a, JniHandleOwnership b) : base (a, b)
		{
			
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			AppContext = this;

			SetupInsight();
		}

		void SetupInsight ()
		{
			Insights.Initialize(Keys.XAMARIN_INSIGHT_KEY, AppContext);

			Insights.HasPendingCrashReport += async(sender, isStartupCrash) =>
			{
				if (isStartupCrash)
				{
					await Insights.PurgePendingCrashReports();
				}
			};
		}
	}
}

