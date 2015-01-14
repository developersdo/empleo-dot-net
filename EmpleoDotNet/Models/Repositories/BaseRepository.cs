using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EmpleoDotNet.Models.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected DbContext context = new Models.Database();
        protected DbSet<T> dbSet;
        public BaseRepository()
        {
            dbSet = context.Set<T>();
        }
        protected T GetById(int id)
        {
            return dbSet.Find(id);
        }
        protected IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}