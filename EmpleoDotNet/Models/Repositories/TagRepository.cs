using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private readonly Database _database = new Database();
        #region Constructor

        public TagRepository(DbContext context)
        {
            this.Context = context;
        }

        #endregion

        #region Methods
        public List<Tag> GetAllTags()
        {
            var result = GetAll().ToList();

            return result;
        }

        public Tag GetTagById(int id)
        {
            var result = GetAll().FirstOrDefault(a => a.Id == id);

            return result;
        }

        public void Update(Tag tag)
        {
            Context.Entry(tag).State = EntityState.Modified;
        }

        public void Delete(Tag tag)
        {
            _database.Tags.Remove(tag); 
        }

        #endregion
    }
}