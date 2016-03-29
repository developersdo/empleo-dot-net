using System;
using Core;
using Android.Graphics;
using Android.Views;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace Android
{
	public class CategoriesFragmentViewModel : ViewModelBase
	{
		public List<CategoriesViewModel> Categories { get; set; }

		public RelayCommand<CategoriesViewModel> OnCategorySelectedCommand { get; set; }

		public CategoriesFragmentViewModel ()
		{
			OnCategorySelectedCommand = new RelayCommand<CategoriesViewModel>(OnCategorySelected);

			Categories = new List<CategoriesViewModel> {
				new CategoriesViewModel {
					Title = "WEB DEVELOPMENT",
					Image = Resource.Drawable.image1,
					Query = "Web development"
				},
				new CategoriesViewModel {
					Title = "MOBILE DEVELOPMENT",
					Image = Resource.Drawable.image2,
					Query = "Mobile development"
				},
				new CategoriesViewModel
				{
					Title = "GAME DEVELOPMENT",
					Image = Resource.Drawable.image3,
					Query = "Game development"
				}
			};
		}

		void OnCategorySelected (CategoriesViewModel model)
		{
			MessengerInstance.Send<NotifySearchBarPutText>(new NotifySearchBarPutText
				{
					Query = model.Query
				});
		}
	}
}