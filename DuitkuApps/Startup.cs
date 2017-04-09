using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DuitkuApps.Startup))]
namespace DuitkuApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
