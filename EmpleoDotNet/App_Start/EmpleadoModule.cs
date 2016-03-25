using System.Data.Entity;
using System.Web.Mvc;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.Services;
using EmpleoDotNet.Services.Social.Twitter;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Mvc.FilterBindingSyntax;

namespace EmpleoDotNet.App_Start
{
    public class EmpleadoModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<EmpleadoContext>().ToSelf().InRequestScope();

            Kernel.Bind<IJobOpportunityRepository>().To<JobOpportunityRepository>();
            Kernel.Bind<ITagRepository>().To<TagRepository>();
            Kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>();

            Kernel.Bind<IJobOpportunityService>().To<JobOpportunityService>();
            Kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
            
            Kernel.Bind<IUserStore<IdentityUser>>().To<UserStore<IdentityUser>>();
            Kernel.Bind<DbContext>().To<EmpleadoContext>();
            Kernel.Bind<IUserProfileSocialService>().To<UserProfileSocialService>();

            Kernel.Bind<ITwitterService>().To<TwitterService>();

            Kernel.Bind<ISettingsProvider>().To<ConfigurationManagerSettingsProvider>();

            Kernel.BindFilter<UnderMaintenanceFilterAttribute>(FilterScope.Global, 1).InRequestScope();
        }
    }
}