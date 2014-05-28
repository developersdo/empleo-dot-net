using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    public class VacantModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ContactInfoModel ContactInfo { get; set; }
    }
}