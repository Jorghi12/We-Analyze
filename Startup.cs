using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Open_Source_Data.Startup))]
namespace Open_Source_Data
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
