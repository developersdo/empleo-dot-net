﻿using System.Data.Entity;
using System.Linq;

namespace EmpleoDotNet.Models.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected DbContext Context;
        protected DbSet<T> DbSet;

        public BaseRepository()
        {
            Context = new Models.Database();
            DbSet = Context.Set<T>();
        }

        public BaseRepository(DbContext context)
        {
            Context = context;
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