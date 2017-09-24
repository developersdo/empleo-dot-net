using EmpleoDotNet.AppServices;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.WebAPI.Services;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Data.Entity;

namespace EmpleoDotNet.WebApi.App_Start
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<DbContext>().To<EmpleadoContext>();
            Kernel.Bind<EmpleadoContext>().ToSelf().InRequestScope();

            Kernel.Bind<IJobOpportunityRepository>().To<JobOpportunityRepository>();
            Kernel.Bind<IJobOpportunityService>().To<JobOpportunityService>();
            Kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>();

            Kernel.Bind<IJobOpportunityToMobileJobAdapter>().To<JobOpportunityToMobileJobAdapter>();

        }
    }

}