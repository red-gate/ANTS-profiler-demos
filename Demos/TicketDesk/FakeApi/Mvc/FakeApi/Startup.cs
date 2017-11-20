using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FakeApi.Startup))]
namespace FakeApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
