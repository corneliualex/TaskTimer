using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskTimer.Startup))]
namespace TaskTimer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
