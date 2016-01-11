using System.Collections.Generic;

namespace EmpleoDotNet.Models.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();

        Tag GetTagById(int id);
    }
}
