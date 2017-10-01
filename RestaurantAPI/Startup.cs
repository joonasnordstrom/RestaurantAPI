using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantAPI.Startup))]
namespace RestaurantAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
