using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EmpleoDotNet.Models.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    { 
        public List<Tag> GetAllTags()
        {
            var tags = GetAll().ToList();
            return tags;
        }
         
        public Tag GetTagById(int id)
        {
            var tag = GetAll().FirstOrDefault(a => a.Id == id);
            return tag;
        }

        public TagRepository(DbContext context):base(context)
        {
            
        }
    }
}