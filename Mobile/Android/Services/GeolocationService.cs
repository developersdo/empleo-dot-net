using System;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using Android.OS;
using Android.Locations;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace Android
{

	public class GeolocationService : Java.Lang.Object, Android.Locations.ILocationListener,IGeolocationService
	{
		public LocationData GetLastKnownUserLocation {
			get {
				return _lastKnownLocation;
			}
		}

		LocationManager _locationManager;

		LocationData _lastKnownLocation;

		string _locationProvider;

		const string LocationService = "location";

		public event EventHandler<UserLocationChangedEventArgs> UserLocationChangedEvent;

		public GeolocationService ()
		{
			_locationManager = (LocationManager)EmpleadoApp.AppContext.GetSystemService (LocationService);

			Criteria criteriaForLocationService = new Criteria
			{
				Accuracy = Accuracy.Fine
			};

			_locationProvider = GetAvailableProvider(criteriaForLocationService);

			Connect();

			GetLastKnownUpdate();
		}

		async void GetLastKnownUpdate ()
		{
			var location = _locationManager.GetLastKnownLocation (LocationManager.NetworkProvider);

			_lastKnownLocation = await ReverseGeocodeCurrentLocation(location);

			OnUserLocationChangedEvent(new UserLocationChangedEventArgs(()=>_lastKnownLocation));
		}

		string GetAvailableProvider (Criteria criteriaForLocationService)
		{
			var acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

			return acceptableLocationProviders.Any() ? acceptableLocationProviders.First () : string.Empty;
		}

		public async void OnLocationChanged (Location location)
		{
			_lastKnownLocation = await ReverseGeocodeCurrentLocation(location);

			OnUserLocationChangedEvent(new UserLocationChangedEventArgs(()=>_lastKnownLocation));
		}

		async Task<LocationData> ReverseGeocodeCurrentLocation(Location location)
		{
			return await Task.Run<LocationData>(async()=>{

				var geocoder = new Geocoder(EmpleadoApp.AppContext);

				var addressList =
					await geocoder.GetFromLocationAsync(location.Latitude, location.Longitude, 10);

				var address = addressList.FirstOrDefault();

				var locationData = new LocationData
				{
					UserCity = address.Locality,
					UserCountry = address.AdminArea,
					UserStreet = address.Thoroughfare,
					PostalCode = address.PostalCode
				};

				return locationData;

			});
		}

		public void Connect()
		{
			_locationManager.RequestLocationUpdates(_locationProvider, 5000, 2, this);
		}

		public void Disconnect()
		{
			_locationManager.RemoveUpdates(this);
		}

		public void OnProviderDisabled (string provider)
		{
			//Too lazy for today, you can submit your PR to handle this...
		}

		public void OnProviderEnabled (string provider)
		{
			_locationProvider = provider;
		}

		public void OnStatusChanged (string provider, Availability status, Bundle extras)
		{
			//Too lazy for today, you can submit your PR to handle this...
		}

		protected virtual void OnUserLocationChangedEvent (UserLocationChangedEventArgs e)
		{
			var handler = UserLocationChangedEvent;
			if (handler != null)
				handler (this, e);
		}
	}
}
