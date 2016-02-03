using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Repository.Contracts;

namespace EmpleoDotNet.Services
{
    public class LocationService : ILocationService
    {
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

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        private readonly ILocationRepository _locationRepository;
    }
}