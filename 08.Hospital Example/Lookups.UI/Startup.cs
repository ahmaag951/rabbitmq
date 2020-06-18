using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lookups.UI.Startup))]
namespace Lookups.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
