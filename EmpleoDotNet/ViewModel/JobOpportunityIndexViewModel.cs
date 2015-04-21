using EmpleoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.ViewModel
{
    public class JobOpportunityIndexViewModel
    {
        #region Property
        public int Id { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        #endregion
    }
}