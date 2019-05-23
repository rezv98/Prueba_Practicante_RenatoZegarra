using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practicante.Startup))]
namespace Practicante
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
