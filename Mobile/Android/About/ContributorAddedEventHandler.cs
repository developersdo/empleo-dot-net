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
using Core;

namespace Android
{	
	public class ContributorAddedEventHandler : EventArgs
	{
		public GithubUser User { get; set; }
	}
}

