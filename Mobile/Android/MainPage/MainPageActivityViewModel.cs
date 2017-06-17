using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using GalaSoft.MvvmLight.Views;

namespace Android
{
	public class MainPageActivityViewModel : ViewModelBase
	{
		ILanguageService _languageService;

		public ObservableCollection<OptionMenu> OptionsMenu { get; set; }

		public RelayCommand<int> OptionMenuSelectedCommand { get; set; }

		INavigationService _navigationService;

		public MainPageActivityViewModel (ILanguageService languageService, 
			INavigationService navigationService)
		{
			_navigationService = navigationService;

			_languageService = languageService;

			OptionMenuSelectedCommand = new RelayCommand<int>(OnOptionMenuSelected);
		}

		void OnOptionMenuSelected (int position)
		{
			var item = OptionsMenu.FirstOrDefault(x => x.Id == position);

			if(item.OnSelected != null)
			{
				item.OnSelected();
			}
		}

		void OnFirstItemSelected ()
		{
			_navigationService.NavigateTo(ScreenName.AboutScreen);
		}

		public override void OnCreate ()
		{
			OptionsMenu = new ObservableCollection<OptionMenu>
			{
//				new OptionMenu
//				{
//					Text = _languageService.GetStringFor("about"),
//					Id = 0001,
//					OnSelected = OnFirstItemSelected
//				}
			};
		}
	}
}

