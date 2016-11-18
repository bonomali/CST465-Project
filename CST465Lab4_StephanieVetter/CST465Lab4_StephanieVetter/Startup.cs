using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CST465Lab4_StephanieVetter.Startup))]
namespace CST465Lab4_StephanieVetter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}