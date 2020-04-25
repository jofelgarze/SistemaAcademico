using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAcademico.Presentacion.Web.Seguridad
{
    public partial class AsignarRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAsignarUsuario_Click(object sender, EventArgs e)
        {
            sdsUsuariosDDL.Insert();
            dgvUsuarios.DataBind();
        }

        protected void dgvUsuarios_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            ddlUsuarios.DataBind();
        }
    }
}