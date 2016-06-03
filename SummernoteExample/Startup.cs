using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SummernoteExample.Startup))]
namespace SummernoteExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
