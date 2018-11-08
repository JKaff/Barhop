using Microsoft.Owin;
using Owin;
using Vidly.ScheduledTasks.ScheduledTasks;

[assembly: OwinStartupAttribute(typeof(Vidly.Startup))]
namespace Vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            YelpDatabaseRefresher.Main();
        }
    }
}
