using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenVanChinh_Lab456.Startup))]
namespace NguyenVanChinh_Lab456
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
