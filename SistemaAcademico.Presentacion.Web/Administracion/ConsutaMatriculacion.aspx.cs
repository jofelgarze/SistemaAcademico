using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAcademico.Presentacion.Web.Administracion
{
    public partial class ConsutaMatriculacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarRegistros();
        }

        private void CargarRegistros() {
            MatriculacionService.MatriculacionServiceClient serviceClient = new MatriculacionService.MatriculacionServiceClient();
            var resultado = serviceClient.ConsultarEstudiantesMatriculados();
            grvEstudianes.DataSource = resultado.Datos;
            grvEstudianes.DataBind();
        }

        protected void colBtnModificar_Click(object sender, EventArgs e)
        {
            int fila = ((System.Web.UI.WebControls.GridViewRow)(sender as LinkButton).DataItemContainer).RowIndex;
            string codigoEstudiante = grvEstudianes.Rows[fila].Cells[0].Text;
            Response.Redirect("/Administracion/ModificarEstudiante.aspx?Id=" + codigoEstudiante,true);
        }

        protected void colBtnEliminar_Click(object sender, EventArgs e)
        {
            int fila = ((System.Web.UI.WebControls.GridViewRow)(sender as LinkButton).DataItemContainer).RowIndex;
            string codigoEstudiante = grvEstudianes.Rows[fila].Cells[0].Text;

            MatriculacionService.MatriculacionServiceClient serviceClient = new MatriculacionService.MatriculacionServiceClient();

            var resultado = serviceClient.EliminarEstudianteMatriculado(int.Parse(codigoEstudiante));

            if (resultado.TipoRespuesta == MatriculacionService.TipoRespuestaEnum.OK)
            {
                CargarRegistros();
                pnlMensaje.CssClass = "alert alert-success";
                pnlMensaje.Visible = true;
                lblMensaje.Text = resultado.Mensaje;
            }
            else
            {
                pnlMensaje.CssClass = "alert alert-danger";
                pnlMensaje.Visible = true;
                lblMensaje.Text = resultado.Mensaje;
            }
        }
    }
}