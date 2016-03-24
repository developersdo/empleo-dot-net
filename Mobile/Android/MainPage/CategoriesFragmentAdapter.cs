using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.App;
using Android.Graphics;
using Android.Content.Res;
using System.Threading.Tasks;
using Core;

namespace Android
{
	public class CategoriesFragmentAdapter : BaseAdapter
	{
		IBitmapResizer<Bitmap> _bitmapResizer;

		LayoutInflater _inflater;

		List<CategoriesViewModel> _items;

		public override int Count {
			get {
				return _items.Count;
			}
		}

		public CategoriesFragmentAdapter(Context context) {

			_bitmapResizer = new BitmapResizer ();
			
			_inflater = LayoutInflater.FromContext(context);

			_items = new List<CategoriesViewModel> {
				new CategoriesViewModel {
					Title = "WEB DEVELOPMENT",
					Image = Resource.Drawable.image1
				},
				new CategoriesViewModel {
					Title = "MOBILE DEVELOPMENT",
					Image = Resource.Drawable.image2
				},
				new CategoriesViewModel
				{
					Title = "GAME DEVELOPMENT",
					Image = Resource.Drawable.image3
				}
			};
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{ 
			var view = convertView ?? _inflater.Inflate(Resource.Layout.CategoriesLayout, null);

			var data = _items [position];

			var title = view.FindViewById<TextView> (Resource.Id.title);

			var image = view.FindViewById<ImageView>(Resource.Id.image);

			title.Text = data.Title;

			using(var bitmapToDisplay = _bitmapResizer.ResizeImageFromResources(data.Image,100, 100))
				image.SetImageBitmap(bitmapToDisplay);

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