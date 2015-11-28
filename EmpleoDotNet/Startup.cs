using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpleoDotNet.Startup))]
namespace EmpleoDotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          
        }
    }
}
