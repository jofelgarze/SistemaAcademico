using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaAcademico.Presentacion.Web.Startup))]
namespace SistemaAcademico.Presentacion.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
