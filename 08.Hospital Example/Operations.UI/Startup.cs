using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Operations.UI.Startup))]
namespace Operations.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
