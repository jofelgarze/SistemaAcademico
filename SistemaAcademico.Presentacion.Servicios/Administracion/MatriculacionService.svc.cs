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

        public Respuesta<MatriculacionEstudianteRespDto> ConsultarEstudianteMatriculado(int Identificacion)
        {
            try
            {
                return new Respuesta<MatriculacionEstudianteRespDto>()
                {
                    Codigo = 0,
                    Mensaje = "",
                    TipoRespuesta = TipoRespuestaEnum.OK,
                    Datos = matriculacion.ConsultarRegistroEstudiante(Identificacion)
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<MatriculacionEstudianteRespDto>()
                {
                    Codigo = 500,
                    Mensaje = "Error al consultar registro: " + ex.Message,
                    TipoRespuesta = TipoRespuestaEnum.ERROR
                };
            }
            
        }

        public Respuesta<List<MatriculacionEstudianteRespDto>> ConsultarEstudiantesMatriculados()
        {
            try
            {
                return new Respuesta<List<MatriculacionEstudianteRespDto>>()
                {
                    Codigo = 0,
                    Mensaje = "",
                    TipoRespuesta = TipoRespuestaEnum.OK,
                    Datos = matriculacion.ConsultarEstudiantes()
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<List<MatriculacionEstudianteRespDto>>()
                {
                    Codigo = 500,
                    Mensaje = "Error al consultar registro: " + ex.Message,
                    TipoRespuesta = TipoRespuestaEnum.ERROR
                };
            }
        }

        public Respuesta<MatriculacionEstudianteRespDto> ModificarEstudianteMatriculado(int Identificacion, MatriculacionEstudianteDto Datos)
        {
            try
            {
                var resultado = matriculacion.ModificarEstudianteMatriculado(Identificacion, Datos);

                return new Respuesta<MatriculacionEstudianteRespDto>()
                {
                    Codigo = 0,
                    Mensaje = "Se actualizo el estudiante con exito",
                    TipoRespuesta = TipoRespuestaEnum.OK,
                    Datos = resultado
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<MatriculacionEstudianteRespDto>()
                {
                    Codigo = 500,
                    Mensaje = "Error al actualizar registro: " + ex.Message,
                    TipoRespuesta = TipoRespuestaEnum.ERROR
                };
            }
        }

        public Respuesta<string> EliminarEstudianteMatriculado(int Identificacion)
        {
            try
            {
                matriculacion.EliminarRegistroEstudiante(Identificacion);
                return new Respuesta<string>()
                {
                    Codigo = 0,
                    Mensaje = "Se elimino el estudiante con exito",
                    TipoRespuesta = TipoRespuestaEnum.OK
                };
            }
            catch (Exception ex)
            {
                return new Respuesta<string>()
                {
                    Codigo = 500,
                    Mensaje = "Error al eliminar registro: " + ex.Message,
                    TipoRespuesta = TipoRespuestaEnum.ERROR
                };
            }
        }
    }
}
