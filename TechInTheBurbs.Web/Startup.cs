using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechInTheBurbs.Startup))]
namespace TechInTheBurbs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
