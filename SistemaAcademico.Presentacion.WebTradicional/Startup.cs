using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaAcademico.Presentacion.WebTradicional.Startup))]
namespace SistemaAcademico.Presentacion.WebTradicional
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
