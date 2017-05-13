using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(emergynetworkService.Startup))]

namespace emergynetworkService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}