using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoDotNet.Core.Domain
{
    public class Permission : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
