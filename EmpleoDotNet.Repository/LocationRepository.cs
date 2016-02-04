using System.Collections.Generic;
using System.Linq;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository.Contracts;

namespace EmpleoDotNet.Repository
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public List<Location> GetAllLocations()
        {
            return GetAll().ToList();
        }

        public List<string> GetAllLocationNames()
        {
            var locations = GetAllLocations();

            return locations.Select(location => location.Name).ToList();
        }

        public Location GetLocationById(int id)
        {
            return GetById(id);
        }

        public Location GetLocationByName(string name)
        {
            var location = GetAll().SingleOrDefault(x => x.Name.Equals(name));
            return location;
        }

        public LocationRepository(EmpleadoContext context) : base(context)
        {
        }
    }
}