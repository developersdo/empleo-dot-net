using System;
using Android.App;
using Android.Content;
using Android.Runtime;

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
		}
	}
}

