using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models.Repositories
{
    public class LocationRepository:BaseRepository<Location>, ILocationRepository
    {

        public List<Location> GetAllLocations()
        {
            return new List<Location>( GetAll().ToList() );
        }

        public List<string> GetAllLocationNames()
        {
            List<string> locationNamesList = new List<string>();

            var locations = GetAllLocations();

            foreach (var location in locations)
                locationNamesList.Add(location.Name);

            return locationNamesList;
        }

        public Location GetLocationById(int id)
        {
            return GetById(id);
        }

        public Location GetLocationByName(string name)
        {
            var location = GetAll().Where(x => x.Name.Equals(name))
                            .SingleOrDefault();
            return location;
        }
    }
}