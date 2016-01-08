using System.Collections.Generic;

namespace EmpleoDotNet.Models.Repositories
{
    public interface ILocationRepository
    {
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        Location GetLocationByName(string name);
    }
}
