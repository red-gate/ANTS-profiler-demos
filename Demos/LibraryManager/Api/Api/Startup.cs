using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Api.Startup))]
namespace Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
