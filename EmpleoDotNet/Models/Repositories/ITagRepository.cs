using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoDotNet.Models.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();

        Tag GetTagById(int id);
    }
}
