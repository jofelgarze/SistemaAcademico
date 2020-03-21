using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Negocio.Dto
{
    public class MatriculacionEstudianteRespDto
    {
        public int CodigoEstudiante { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public DateTime FechaMatriculacion { get; set; }
    }
}
