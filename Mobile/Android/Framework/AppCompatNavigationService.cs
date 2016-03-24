using System;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using Android.Content;

namespace Android
{
	public class AppCompatNavigationService : INavigationService
	{
		private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
		private readonly Dictionary<string, object> _parametersByKey = new Dictionary<string, object>();

		private const string RootPageKey = "-- ROOT --";
		private const string ParameterKeyName = "ParameterKey";

		public string CurrentPageKey { get { return AppCompatActivityBase.CurrentActivity.ActivityKey ?? RootPageKey; }}

		public void GoBack()
		{
			AppCompatActivityBase.GoBack();
		}

		public void NavigateTo(string pageKey)
		{
			NavigateTo(pageKey, null);
		}

		public void NavigateTo(string pageKey, object parameter)
		{
			AppCompatActivityBase.CurrentActivity.RunOnUiThread(() =>
				{
					if (AppCompatActivityBase.CurrentActivity == null)
						throw new InvalidOperationException("No CurrentActivity found");

					lock (_pagesByKey)
					{
						if (!_pagesByKey.ContainsKey(pageKey))
							throw new ArgumentException($"No such page: {pageKey}. Did you forget to call NavigationService.Configure?", nameof(pageKey));

						var intent = new Intent(AppCompatActivityBase.CurrentActivity, _pagesByKey[pageKey]);
						if (parameter != null)
						{
							lock (_parametersByKey)
							{
								var guid = Guid.NewGuid().ToString();
								_parametersByKey.Add(guid, parameter);
								intent.PutExtra(ParameterKeyName, guid);
							}
						}

						AppCompatActivityBase.CurrentActivity.StartActivity(intent);
						AppCompatActivityBase.NextPageKey = pageKey;
					}
				});
		}

		public void Configure(string key, Type activityType)
		{
			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey(key))
					_pagesByKey[key] = activityType;
				else
					_pagesByKey.Add(key, activityType);
			}
		}

		public object GetAndRemoveParameter(Intent intent)
		{
			if (intent == null)
				throw new ArgumentNullException(intent.ToString(), "This method must be called with a valid Activity intent");

			var stringExtra = intent.GetStringExtra(ParameterKeyName);
			if (string.IsNullOrEmpty(stringExtra))
				return null;

			lock (_parametersByKey)
				return _parametersByKey.ContainsKey(stringExtra) ? _parametersByKey[stringExtra] : null;
		}

		public T GetAndRemoveParameter<T>(Intent intent)
		{
			return (T)GetAndRemoveParameter(intent);
		}
	}
}

