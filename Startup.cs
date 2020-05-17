using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Your_Petition.Startup))]
namespace Your_Petition
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
