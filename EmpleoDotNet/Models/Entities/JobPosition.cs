using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models.Entities
{
    public class JobPosition : Entity
    {
        public Int32 UserId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }


        public String ContactName { get; set; }
        public String ContactPhone { get; set; }
        public String ContactEmail { get; set; }
        public String ContactWebSite { get; set; }
        
        public Boolean IsPublished { get; set; }
        public DateTime PublishedDate { get; set; }

    }
}