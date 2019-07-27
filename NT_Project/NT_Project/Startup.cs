using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NT_Project.Startup))]
namespace NT_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
