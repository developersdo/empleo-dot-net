using System.Collections.Generic;

namespace EmpleoDotNet.Core.Dto
{
    public class PagedResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int ItemCount { get; set; }
    }
}