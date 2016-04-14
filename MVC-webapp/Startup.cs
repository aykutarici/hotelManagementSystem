using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_webapp.Startup))]
namespace MVC_webapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
