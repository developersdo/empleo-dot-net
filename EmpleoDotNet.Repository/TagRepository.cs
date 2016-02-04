using System.Collections.Generic;
using System.Linq;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository.Contracts;

namespace EmpleoDotNet.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public List<Tag> GetAllTags()
        {
            return GetAll().ToList();
        }

        public TagRepository(EmpleadoContext context) : base(context)
        {
        }
    }
}