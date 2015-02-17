using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        #region Constructor
        public TagRepository(DbContext context):base(context)
        {
           
        }
        #endregion

        #region Methods
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

        public void Delete(Tag tag)
        {
            tag.Estado = EstadoRegistro.Borrado;
            Update(tag);
        }
        #endregion
    }
}