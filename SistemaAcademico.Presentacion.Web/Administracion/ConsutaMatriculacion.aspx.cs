﻿using System;
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
            MatriculacionService.MatriculacionServiceClient serviceClient = new MatriculacionService.MatriculacionServiceClient();
            var resultado = serviceClient.ConsultarEstudiantesMatriculados();
            grvEstudianes.DataSource = resultado.Datos;
            grvEstudianes.DataBind();
        }
    }
}