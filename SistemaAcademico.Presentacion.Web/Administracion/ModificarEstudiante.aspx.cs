using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAcademico.Presentacion.Web.Administracion
{
    public partial class ModificarEstudiante : System.Web.UI.Page
    {
        private MatriculacionService.MatriculacionServiceClient serviceClient;

        private DateTime FechaNacimiento;

        public ModificarEstudiante()
        {
            serviceClient = new MatriculacionService.MatriculacionServiceClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int codigoEstudiante;
                if (!int.TryParse(Request.Params.Get("Id"), out codigoEstudiante))
                {
                    pnlMensaje.CssClass = "alert alert-danger";
                    pnlMensaje.Visible = true;
                    lblMensaje.Text = "Operacion invalida";
                    return;
                }
                var resultado = serviceClient.ConsultarEstudianteMatriculado(codigoEstudiante);
                if (resultado.TipoRespuesta == MatriculacionService.TipoRespuestaEnum.OK && resultado.Datos != null)
                {
                    btnCancelar_Click(null, null);
                    txtNombres.Text = resultado.Datos.Nombres;
                    txtApellidos.Text = resultado.Datos.Apellidos;
                    chkPagoRealizado2.Checked = true;
                    FechaNacimiento = resultado.Datos.FechaMatriculacion;
                }
                else
                {
                    pnlMensaje.CssClass = "alert alert-danger";
                    pnlMensaje.Visible = true;
                    lblMensaje.Text = resultado.Mensaje;
                }

            }
            

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int codigoEstudiante;
            if (!int.TryParse(Request.Params.Get("Id"),out codigoEstudiante))
            {
                pnlMensaje.CssClass = "alert alert-danger";
                pnlMensaje.Visible = true;
                lblMensaje.Text = "Operacion invalida";
            }            

           

            var parametros = new MatriculacionService.MatriculacionEstudianteDto();
            parametros.PrimerNombre = txtNombres.Text;
            parametros.PrimerApellido = txtApellidos.Text;
            parametros.PagoRealizado = chkPagoRealizado2.Checked;
            parametros.FechaNacimiento = DateTime.UtcNow.AddYears(-25);

            var resultado = serviceClient.ModificarEstudianteMatriculado(codigoEstudiante, parametros);

            if (resultado.TipoRespuesta == MatriculacionService.TipoRespuestaEnum.OK)
            {
                pnlMensaje.CssClass = "alert alert-success";
                pnlMensaje.Visible = true;
                lblMensaje.Text = resultado.Mensaje + "; Id. Estudiante: " + resultado.Datos.CodigoEstudiante;
            }
            else
            {
                pnlMensaje.CssClass = "alert alert-danger";
                pnlMensaje.Visible = true;
                lblMensaje.Text = resultado.Mensaje;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Administracion/ConsutaMatriculacion.aspx");

        }
    }
}