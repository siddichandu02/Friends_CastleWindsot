using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WindsorMvcDemo.Startup))]
namespace WindsorMvcDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
