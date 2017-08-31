using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Highlighter.Startup))]
namespace Highlighter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
