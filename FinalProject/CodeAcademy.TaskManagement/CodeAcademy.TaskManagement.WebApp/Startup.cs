using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeAcademy.TaskManagement.WebApp.Startup))]
namespace CodeAcademy.TaskManagement.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
