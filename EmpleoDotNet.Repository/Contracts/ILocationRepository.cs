using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Repository.Contracts
{
    public interface ILocationRepository : IBaseRepository<Location>
    {
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        Location GetLocationByName(string name);
    }
}
