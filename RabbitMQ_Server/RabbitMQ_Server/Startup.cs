using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RabbitMQ_Server.Startup))]
namespace RabbitMQ_Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
