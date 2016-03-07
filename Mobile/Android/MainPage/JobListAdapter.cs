using System;
using System.Collections.Generic;

using Android.Views;
using Android.App;
using Android.Widget;

using Android.ViewModels;

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
				new JobItemViewModel {
					Title = "Junior Mobile Developer",
					IsRemote = true,
					CompanyName = "Megsoft Consulting",
					Location = "Santo Domingo"
				},
				new JobItemViewModel {
					Title = "Senior Mobile Developer",
					IsRemote = true,
					Location = "New York",
					CompanyName = "Megsoft Consulting"
				},
				new JobItemViewModel {
					Title = "Junior Web Developer",
					IsRemote = true,
					CompanyName = "Megsoft Consulting"
				},
				new JobItemViewModel {
					Title = "Junior Mobile Developer",
					IsRemote = false,
					CompanyName = "Megsoft Consulting"
				},
				new JobItemViewModel {
					Title = "Senior Mobile Developer",
					IsRemote = true,
					CompanyName = "Megsoft Consulting"
				},
				new JobItemViewModel {
					Title = "Junior Web Developer",
					IsRemote = true,
					CompanyName = "Megsoft Consulting"
				},
				new JobItemViewModel {
					Title = "Junior Mobile Developer",
					IsRemote = false,
					CompanyName = "Megsoft Consulting"
				},
				new JobItemViewModel {
					Title = "Senior Mobile Developer",
					IsRemote = true,
					CompanyName = "Megsoft Consulting"
				},
				new JobItemViewModel {
					Title = "Junior Web Developer",
					IsRemote = true,
					CompanyName = "Megsoft Consulting"
				}
			};
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{ 
			var view = convertView ?? _inflater.Inflate (Resource.Layout.JobCardLayout, null);

			var data = _items [position];

			var title = view.FindViewById<TextView> (Resource.Id.JobCardTitleTextView);

			var company = view.FindViewById<TextView> (Resource.Id.JobCardCompanyTextView);

			var location = view.FindViewById<TextView> (Resource.Id.JobCardLocationTextView);

			var remote = view.FindViewById<TextView> (Resource.Id.JobCardRemoteTextView);

			var isRemoteIcon = view.FindViewById<ImageView> (Resource.Id.JobCardRemoteImageView);

			title.Text = data.Title;

			company.Text = data.CompanyName;

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

