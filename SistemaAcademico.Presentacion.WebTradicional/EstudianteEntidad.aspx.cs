using SistemaAcademico.Presentacion.WebTradicional.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAcademico.Presentacion.WebTradicional
{
    public partial class EstudianteEntidad : System.Web.UI.Page
    {
        private RepEstudiantes repositorio = new RepEstudiantes();
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlFrmEstudiante.Visible = User.Identity.IsAuthenticated && User.IsInRole("Administrador");
        }

        private void LimpiarCampos()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtFechaNac.Text = "";
            chkActivo.Checked = false;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var est = new Entidades.Estudiante();
            est.Nombres = txtNombres.Text;
            est.Apellidos = txtApellidos.Text;
            est.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
            est.Activo = chkActivo.Checked;
            repositorio.crear(est);
            LimpiarCampos();
            //odsEstudiante.DataBind();
            dgvEstudiantes.DataBind();
        }

        protected void dgvEstudiantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                repositorio.eliminar(Int32.Parse(e.CommandArgument.ToString()));
                dgvEstudiantes.DataBind();
            }
        }
    }
}