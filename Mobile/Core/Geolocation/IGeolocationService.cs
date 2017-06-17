using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Android
{
	public interface IGeolocationService
	{
		event EventHandler<UserLocationChangedEventArgs> UserLocationChangedEvent;

		LocationData GetLastKnownUserLocation { get; }
	}

}

