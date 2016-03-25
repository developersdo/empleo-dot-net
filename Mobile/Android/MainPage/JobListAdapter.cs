using System;
using System.Collections.Generic;

using Android.Views;
using Android.App;
using Android.Widget;

using Android.ViewModels;
using Android.Graphics;
using Android.Support.V7.Widget;

namespace Android
{
	public class JobListAdapter : BaseAdapter
	{
		Activity _activity;

		LayoutInflater _inflater;

		List<JobItemViewModel> _items;

		public override int Count {
			get {
				return _items.Count;
			}
		}

		public JobListAdapter(Activity activity) {

			_activity = activity;
			
			_inflater = activity.LayoutInflater;

			_items = new List<JobItemViewModel> {
				
			};
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{ 
			var view = convertView ?? _inflater.Inflate (Resource.Layout.JobCardLayout, null);

			var data = _items [position];

			var title = view.FindViewById<TextView> (Resource.Id.JobCardTitleTextView);

			var company = view.FindViewById<TextView> (Resource.Id.JobCardCompanyTextView);

			var location = view.FindViewById<TextView> (Resource.Id.JobCardLocationTextView);

			var locationIcon = view.FindViewById<AppCompatImageView>(Resource.Id.locationIcon);

			var remote = view.FindViewById<TextView> (Resource.Id.JobCardRemoteTextView);

			var isRemoteIcon = view.FindViewById<ImageView> (Resource.Id.JobCardRemoteImageView);

			var category = view.FindViewById<TextView>(Resource.Id.JobCategory);

			title.Text = data.Title;

			company.Text = data.CompanyName;

			category.Text = data.Category;

			locationIcon.Visibility = string.IsNullOrEmpty(data.Location) ? ViewStates.Invisible : ViewStates.Visible;

			location.Text = data.Location;

			remote.Text = data.IsRemote ? _activity.GetString(Resource.String.IsRemote) : string.Empty;

			isRemoteIcon.Visibility = data.IsRemote ? ViewStates.Visible : ViewStates.Invisible;

			return view;
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return position;
		}
	}
}

