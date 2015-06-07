using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EsraBlog.Startup))]
namespace EsraBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
