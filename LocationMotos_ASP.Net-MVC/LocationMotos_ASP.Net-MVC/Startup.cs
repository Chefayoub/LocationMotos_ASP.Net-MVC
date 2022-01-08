using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocationMotos_ASP.Net_MVC.Startup))]
namespace LocationMotos_ASP.Net_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
