using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public int BuildingNumber { get; set; }
    }
}