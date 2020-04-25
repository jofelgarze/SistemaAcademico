using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAcademico.Presentacion.Web.Models
{
    public class MatriculacionBL
    {
        private MatriculacionService.MatriculacionServiceClient servicio;

        public MatriculacionBL()
        {
            servicio = new MatriculacionService.MatriculacionServiceClient();
        }

        public List<Estudiante> consultarTodos() {
            var resp = servicio.ConsultarEstudiantesMatriculados();
            var datos = resp.Datos;

            if (resp.TipoRespuesta == MatriculacionService.TipoRespuestaEnum.OK)
            {
                return datos.Select(d => new Estudiante (){ 
                    Id = d.CodigoEstudiante,
                    Nombres = d.Nombres,
                    Apellidos = d.Apellidos,
                    Activo = true,
                    FechaNacimiento = d.FechaMatriculacion
                }).ToList();
            }
            return new List<Estudiante>();
        }

        public Estudiante insertar(Estudiante data) { 
            var resp = servicio.RegistrarEstudianteNuevo(new MatriculacionService.MatriculacionEstudianteDto { 
                PrimerNombre = data.Nombres,
                PrimerApellido = data.Apellidos,
                FechaNacimiento = data.FechaNacimiento,
                PagoRealizado = data.Activo
            });
            var id = resp.Datos;

            if (resp.TipoRespuesta == MatriculacionService.TipoRespuestaEnum.OK)
            {
                data.Id = id;
                return data;
            }
            return null;
        }

        public Estudiante modificar(Estudiante data)
        {
            var resp = servicio.ModificarEstudianteMatriculado(data.Id, 
                new MatriculacionService.MatriculacionEstudianteDto
                {
                    PrimerNombre = data.Nombres,
                    PrimerApellido = data.Apellidos,
                    FechaNacimiento = DateTime.UtcNow.AddYears(-18),
                    PagoRealizado = data.Activo
                });
            var datos = resp.Datos;

            if (resp.TipoRespuesta == MatriculacionService.TipoRespuestaEnum.OK)
            {
                return data;
            }
            return null;
        }

        public void eliminar(Estudiante data)
        {
            var resp = servicio.EliminarEstudianteMatriculado(data.Id);
            var datos = resp.Datos;
        }
    }
}