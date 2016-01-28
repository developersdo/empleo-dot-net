using EmpleoDotNet.Models;

namespace EmpleoDotNet.Helpers
{
    public class JobCategoryLinkViewModel
    {
        public string Description { get; set; }
        public JobCategory JobCategory { get; set; }
        public int JobQuantity { get; set; }
    }
}