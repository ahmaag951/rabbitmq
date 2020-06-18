using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserManagement.UI.Startup))]
namespace UserManagement.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
