using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MCM.KidsIdApp.MobileApp.Startup))]

namespace MCM.KidsIdApp.MobileApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureMobileApp(app);
        }
    }
}