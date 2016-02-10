using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Core.Dto
{
    public class JobCategoryCountDto
    {
        public JobCategory JobCategory { get; set; }
        public int Count { get; set; }
    }
}