using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Invest.Web.Startup))]
namespace Invest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
