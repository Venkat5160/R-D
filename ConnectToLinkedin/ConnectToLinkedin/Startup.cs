using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConnectToLinkedin.Startup))]
namespace ConnectToLinkedin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }     
    }   
}
