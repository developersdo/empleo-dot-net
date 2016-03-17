using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;

namespace Android
{
	public class LandingPageFragment : Fragment
	{
		public LandingPageInfo LandingPageInfo { get; set; }

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.LandingPageFragmentLayout, container, false);

			var title = view.FindViewById<TextView>(Resource.Id.title);

			var description = view.FindViewById<TextView>(Resource.Id.description);

			var icon = view.FindViewById<ImageView>(Resource.Id.icon);

			title.SetText(LandingPageInfo.Title);

			description.SetText(LandingPageInfo.Description);

			icon.SetImageResource(LandingPageInfo.Icon);

			return view;
		}
	}
}

