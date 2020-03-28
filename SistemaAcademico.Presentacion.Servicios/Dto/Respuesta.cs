using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAcademico.Presentacion.Servicios.Dto
{
    public class Respuesta<T>
    {
        public int Codigo { get; set; } 
        public string Mensaje { get; set; }
        public TipoRespuestaEnum TipoRespuesta { get; set; }
        public T Datos { get; set; }

    }
}