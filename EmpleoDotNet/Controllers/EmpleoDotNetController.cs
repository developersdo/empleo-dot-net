using System.Data.Entity;
using System.Web.Mvc;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.Controllers
{
    public abstract class EmpleoDotNetController : Controller
    {
        protected readonly DbContext _database;
        protected readonly IUnitOfWork _uow;

        protected EmpleoDotNetController()
        {
            _database = new EmpleadoContext();
            _uow = new EntityFrameworkUnitOfWork(_database);
        }
    }
}