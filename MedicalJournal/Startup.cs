using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedicalJournal.Startup))]
namespace MedicalJournal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
