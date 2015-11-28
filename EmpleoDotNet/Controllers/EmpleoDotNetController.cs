using System.Data.Entity;
using System.Web.Mvc;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.Controllers
{
    public class EmpleoDotNetController : Controller
    {
        protected readonly DbContext _database;
        protected readonly IUnitOfWork _uow;

        public EmpleoDotNetController()
        {
            _database = new Models.EmpleadoContext();
            _uow = new EntityFrameworkUnitOfWork(_database);
        }
    }
}