using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Repository.Contracts
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        List<Tag> GetAllTags();
    }
}
