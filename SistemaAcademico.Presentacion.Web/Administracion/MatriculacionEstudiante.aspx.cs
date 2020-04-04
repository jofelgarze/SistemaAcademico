using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAcademico.Presentacion.Web.Administracion
{
    public partial class MatriculacionEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMatricular_Click(object sender, EventArgs e)
        {
            MatriculacionService.MatriculacionServiceClient serviceClient = new MatriculacionService.MatriculacionServiceClient();
            var resultado = serviceClient.RegistrarEstudianteNuevo(new MatriculacionService.MatriculacionEstudianteDto
            {
                PrimerNombre = txtNombres.Text,
                PrimerApellido = txtApellidos.Text,
                PagoRealizado = chkPagoRealizado.Checked,
                FechaNacimiento = DateTime.UtcNow.AddYears(-18)               
            });            
            if (resultado.TipoRespuesta == MatriculacionService.TipoRespuestaEnum.OK)
            {
                btnCancelar_Click(null,null);
                pnlMensaje.CssClass = "alert alert-success";
                pnlMensaje.Visible = true;
                lblMensaje.Text = resultado.Mensaje + "; Id. Estudiante: " + resultado.Datos;
            }
            else {
                pnlMensaje.CssClass = "alert alert-danger";
                pnlMensaje.Visible = true;
                lblMensaje.Text = resultado.Mensaje;
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlMensaje.CssClass = "";
            pnlMensaje.Visible = false;
            lblMensaje.Text = "";

            txtApellidos.Text = "";
            txtNombres.Text = "";
            chkPagoRealizado.Checked = false;

        }
    }
}