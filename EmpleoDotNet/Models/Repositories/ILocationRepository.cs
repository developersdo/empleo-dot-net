using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoDotNet.Models.Repositories
{
    public interface ILocationRepository
    {
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        Location GetLocationByName(string name);
    }
}
