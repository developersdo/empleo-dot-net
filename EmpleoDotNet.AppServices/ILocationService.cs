using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.AppServices
{
    public interface ILocationService
    {
        IEnumerable<Location> GetLocationsWithDefault();
        IEnumerable<Location> GetAllLocations();
    }
}