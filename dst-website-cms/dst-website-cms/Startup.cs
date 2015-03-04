using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dst_website_cms.Startup))]
namespace dst_website_cms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
