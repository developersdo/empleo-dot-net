using System;
using System.Collections.ObjectModel;

namespace Android
{
	public class SearchViewModel : ViewModelBase
	{
		IGeolocationService _geolocationViewModel;

		ILanguageService _languageService;

		public string Address { get; set; }

		public ObservableCollection<SearchResultItem> RecentSearch { get; set; }

		public SearchViewModel 
			(IGeolocationService geolocationViewModel,
			ILanguageService languageService)
		{
			_languageService = languageService;

			_geolocationViewModel = geolocationViewModel;

			_geolocationViewModel.UserLocationChangedEvent += OnUserLocationChanged;
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			RecentSearch = new ObservableCollection<SearchResultItem>
			{
				//Usa esta lista para mostrar busqueda recientes
				new SearchResultItem
				{
					Address = "Villa Faro",
					City = "Santo Domingo Este"
				},
				new SearchResultItem
				{
					Address = "City 1004F",
					City = "Amsterdam"
				},
				new SearchResultItem
				{
					Address = "Downtown",
					City = "New York"
				}
			};

			Address = _languageService.GetStringFor("searchNearByLoading");
		}

		void OnUserLocationChanged (object sender, UserLocationChangedEventArgs e)
		{
			UpdateAddress(e.GetLastKnownUserLocation);
		}

		void UpdateAddress (LocationData location)
		{
			if(location != null)
			{
				Address = string.Format("{0}, {1}", location.UserCountry, location.UserCity);
			}
		}
	}
}