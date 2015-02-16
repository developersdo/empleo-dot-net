using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}