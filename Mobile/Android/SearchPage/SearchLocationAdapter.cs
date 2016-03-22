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
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Graphics;
using System.Collections.ObjectModel;

namespace Android
{
	public class SearchLocationAdapter : BaseAdapter
	{
		Context _context;

		ObservableCollection<SearchResultItem> _searchResultItem;

		public override int Count {
			get {
				return _searchResultItem.Count;
			}
		}

		public SearchLocationAdapter (Context context)
		{
			_context = context;

			_searchResultItem = new ObservableCollection<SearchResultItem>
			{
				new SearchResultItem
				{
					City = "Apple Valley",
					Address = "Far Rockaway, NY 11691"
				},
				new SearchResultItem
				{
					City = "Brasil",
					Address = "Fayetteville, NC 28303"
				},
				new SearchResultItem
				{
					City = "Yugoslavia",
					Address = "Twin Falls, ID 83301"
				}
			};
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? LayoutInflater.FromContext(_context).Inflate(Resource.Layout.SearchItemCard, null);

			var data = _searchResultItem[position];

			var city = view.FindViewById<TextView>(Resource.Id.city);

			var address = view.FindViewById<TextView>(Resource.Id.address);

			city.Text = data.City;

			address.Text = data.Address;

			return view;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Java.Lang.Object GetItem (int position)
		{
			throw new NotImplementedException ();
		}
	}
}