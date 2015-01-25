namespace EmpleoDotNet.Models
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}