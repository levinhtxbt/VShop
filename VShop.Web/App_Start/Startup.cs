using Microsoft.Owin;
using Owin;
using VShop.Web.Configurations;

[assembly: OwinStartup(typeof(VShop.Web.App_Start.Startup))]

namespace VShop.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfiguration.Config(app);
            AutoMapperConfiguration.Configure();
        }
    }
}