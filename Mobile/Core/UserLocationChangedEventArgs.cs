using System;
using System.Collections.Generic;
using System.Linq;

namespace Android
{
	public class UserLocationChangedEventArgs : EventArgs
	{
		public LocationData GetLastKnownUserLocation { get; private set; }

		public UserLocationChangedEventArgs (Func<LocationData> action)
		{
			GetLastKnownUserLocation = action.Invoke();
		}
	}
}

