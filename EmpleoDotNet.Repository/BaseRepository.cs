using System.Data.Entity;
using System.Linq;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository.Contracts;

namespace EmpleoDotNet.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected EmpleadoContext Context;
        protected DbSet<T> DbSet;

        public BaseRepository(EmpleadoContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        protected T GetById(int? id)
        {
            return DbSet.Find(id);
        }
        protected IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void SaveChanges()
        {
            //TODO: Implement Unit of Work Pattern
            //Esto permitirá que se pueda grabar de forma transaccional en la BD
            Context.SaveChanges();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }
    }
}