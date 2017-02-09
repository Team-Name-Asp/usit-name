using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelerikColours.Startup))]
namespace TelerikColours
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
