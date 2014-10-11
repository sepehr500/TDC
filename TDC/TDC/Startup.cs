using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TDC.Startup))]
namespace TDC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
