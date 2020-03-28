using SistemaAcademico.Negocio;
using SistemaAcademico.Negocio.Dto;
using SistemaAcademico.Presentacion.Servicios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SistemaAcademico.Presentacion.Servicios.Administracion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MatriculacionService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MatriculacionService.svc o MatriculacionService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MatriculacionService : IMatriculacionService
    {
        UtMatriculacion matriculacion;

        public MatriculacionService()
        {
            matriculacion = new UtMatriculacion();
        }

        public Respuesta<int> RegistrarEstudianteNuevo(MatriculacionEstudianteDto Datos)
        {
            try
            {
                var resultado = matriculacion.MatricularEstudianteNuevo(Datos);

                return new Respuesta<int>() {
                    Codigo = 0,
                    Mensaje = "Se ingreso el estudiante con exito",
                    TipoRespuesta = TipoRespuestaEnum.OK,
                    Datos = resultado.CodigoEstudiante
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<int>()
                {
                    Codigo = 500,
                    Mensaje = "Error al guardar registro: " + ex.Message,
                    TipoRespuesta = TipoRespuestaEnum.ERROR
                };
            }
            
            
        }

        public MatriculacionEstudianteRespDto ConsultarEstudianteMatriculado(int Identificacion)
        {
            return matriculacion.ConsultarRegistroEstudiante(Identificacion);
        }

        public List<MatriculacionEstudianteRespDto> ConsultarEstudiantesMatriculados()
        {
            return matriculacion.ConsultarEstudiantes();
        }

        public MatriculacionEstudianteRespDto ModificarEstudianteMatriculado(int Identificacion, MatriculacionEstudianteDto Datos)
        {
            return matriculacion.ModificarEstudianteMatriculado(Identificacion, Datos);
        }

        public MatriculacionEstudianteRespDto EliminarEstudianteMatriculado(int Identificacion)
        {
            matriculacion.EliminarRegistroEstudiante(Identificacion);
            return null;
        }
    }
}
