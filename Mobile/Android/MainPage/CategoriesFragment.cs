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
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Helpers;
using Android.ViewModels;
using Android.Graphics;
using Core;

namespace Android
{
	public class CategoriesFragment : Fragment, IBackPressed
	{
		ListView _listView;

		CategoriesFragmentViewModel _viewModel;

		IBitmapResizer<Bitmap> _bitmapResizer;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			GetDependencies();

			_viewModel.OnCreate();
		}

		void GetDependencies ()
		{
			_viewModel = ServiceLocator.Current.GetInstance<CategoriesFragmentViewModel>();

			_bitmapResizer = ServiceLocator.Current.GetInstance<IBitmapResizer<Bitmap>>();
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var layout = inflater.Inflate(Resource.Layout.CategoriesFragmentLayout, container, false);

			_listView = layout.FindViewById<ListView> (Resource.Id.categoriesFragment);

			return layout;
		}

		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);

			_listView.Adapter = _viewModel.Categories.GetAdapter(OnJobAdapterView);
		}

		View OnJobAdapterView (int position, CategoriesViewModel data, View convertView)
		{
			var view = convertView ?? LayoutInflater.FromContext(Activity).Inflate(Resource.Layout.CategoriesLayout, null);

			var title = view.FindViewById<TextView> (Resource.Id.title);

			var image = view.FindViewById<ImageView>(Resource.Id.image);

			title.Text = data.Title;

			using(var bitmapToDisplay = _bitmapResizer.ResizeImageFromResources(data.Image,100, 100))
				image.SetImageBitmap(bitmapToDisplay);
			
			return view;
		}

		public override void OnResume ()
		{
			base.OnResume ();

			_listView.ItemClick += OnListViewItemClick;

			_viewModel.OnResume();
		}

		public override void OnStop ()
		{
			base.OnStop ();

			_listView.ItemClick -= OnListViewItemClick;

			_viewModel.OnStop();
		}

		void OnListViewItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			_viewModel.OnCategorySelectedCommand.Execute(_viewModel.Categories[e.Position]);
		}

		public bool OnBackPressed ()
		{
			return new BackPressImpl(this).OnBackPressed();
		}
	}
}