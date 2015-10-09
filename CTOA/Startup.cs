using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CTOA.Startup))]
namespace CTOA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
