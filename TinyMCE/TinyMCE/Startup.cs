using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TinyMCE.Startup))]
namespace TinyMCE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
