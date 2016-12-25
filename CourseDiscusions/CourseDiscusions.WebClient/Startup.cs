using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseDiscusions.WebClient.Startup))]
namespace CourseDiscusions.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
