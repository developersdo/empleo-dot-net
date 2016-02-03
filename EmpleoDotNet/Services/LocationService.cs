using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository;

namespace EmpleoDotNet.Services
{
    public class LocationService
    {
        private LocationRepository _locationRepository;

        public LocationService()
        {
            _locationRepository = new LocationRepository(new EmpleadoContext());
        }

        public IEnumerable<Location> GetLocationsWithDefault()
        {
            var locations = _locationRepository.GetAllLocations();

            locations.Insert(0, new Location { Id = 0, Name = "Todas" });

            return locations;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _locationRepository.GetAllLocations();
        } 
    }
}