using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Repository.Contracts
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();

        Tag GetTagById(int id);
    }
}
