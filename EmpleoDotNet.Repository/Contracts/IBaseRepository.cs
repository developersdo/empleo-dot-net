namespace EmpleoDotNet.Repository.Contracts
{
    public interface IBaseRepository<in T> where T : class
    {
        void SaveChanges();
        void Add(T entity);
    }
}