using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAcademico.Presentacion.WebTradicional
{
    public partial class Estudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos() {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtFechaNac.Text = "";
            chkActivo.Checked = false;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            sdsEstudiantes.Insert();
            LimpiarCampos();
        }
    }
}