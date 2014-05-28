using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    public class ContactInfoModel
    {
        public int Id { get; set; }
        // Company's name or person's name 
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string WebAddress { get; set; }
        public AddressModel Address { get; set; }
    }
}