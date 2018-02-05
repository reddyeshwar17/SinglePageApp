using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularJSMvc.Startup))]
namespace AngularJSMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
