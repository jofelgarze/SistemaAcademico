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
        }

        protected void dgvMatriculas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int fila = e.RowIndex;
            string codigoEstudiante = dgvMatriculas.Rows[fila].Cells[1].Text;

            MatriculacionService.MatriculacionServiceClient serviceClient = new MatriculacionService.MatriculacionServiceClient();

            var resultado = serviceClient.EliminarEstudianteMatriculado(int.Parse(codigoEstudiante));

            if (resultado.TipoRespuesta == MatriculacionService.TipoRespuestaEnum.OK)
            {
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