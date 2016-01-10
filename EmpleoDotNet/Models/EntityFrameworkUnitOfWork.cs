using System.Data.Entity;

namespace EmpleoDotNet.Models
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public EntityFrameworkUnitOfWork(DbContext context)
        {
            _dbContext = context;
        }
    }
}