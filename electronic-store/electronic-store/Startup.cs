using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(electronic_store.Startup))]
namespace electronic_store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
