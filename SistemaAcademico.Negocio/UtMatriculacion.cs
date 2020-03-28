using SistemaAcademico.Datos;
using SistemaAcademico.Datos.Entidades;
using SistemaAcademico.Negocio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Negocio
{
    public class UtMatriculacion : IDisposable
    {
        private IRepositorio<Estudiante, Int32> repEstudiantes;
        private AcademiaContextoDb _contextoDb;
        public UtMatriculacion()
        {
            _contextoDb = new AcademiaContextoDb();
            repEstudiantes = new RepEstudiantes(_contextoDb);
        }

        public void Dispose()
        {
            _contextoDb.Dispose();
        }

        /// <summary>
        /// Registrar un nuevo estudiante en el sistema, se valida que el estudiante no exista previamente;
        /// ademas deberá de tener cancelado los valores adeudados.
        /// </summary>
        /// <param name="dto">
        ///     Datos del estudiante, los campos: <code>nombre</code>,<code>apellido</code>,
        ///     <code>fechaNacimiento</code> son obligatorios
        /// </param>
        /// <returns>Instancia del objeto estudiante con su respectivo Id</returns>
        public Dto.MatriculacionEstudianteRespDto MatricularEstudianteNuevo(Dto.MatriculacionEstudianteDto dto) {

            if (String.IsNullOrEmpty(dto.PrimerNombre))
            {
                throw new ApplicationException("El primer nombre es obligatorio");
            }

            if (String.IsNullOrEmpty(dto.PrimerApellido))
            {
                throw new ApplicationException("El primer nombre es obligatorio");
            }

            if (dto.FechaNacimiento > DateTime.UtcNow.AddYears(-18))
            {
                throw new ApplicationException("Debe ser mayor de edad");
            }

            if (!dto.PagoRealizado)
            {
                throw new ApplicationException("Debe realizar el pago previo a maricularse");
            }

            var estudiante = new Estudiante()
            {
                Nombres = String.Concat(dto.PrimerNombre, " ", dto.SegundoNombre).TrimEnd(),
                Apellidos = String.Concat(dto.PrimerApellido, " ", dto.SegundoApellido).TrimEnd(),
                Activo = dto.PagoRealizado,
                FechaNacimiento = dto.FechaNacimiento
            };
            var resultado = repEstudiantes.crear(estudiante);

            return new Dto.MatriculacionEstudianteRespDto()
            {
                CodigoEstudiante = resultado.Id,
                Nombres = resultado.Nombres,
                Apellidos = resultado.Apellidos,
                FechaMatriculacion = DateTime.UtcNow
            };
        }


        public Dto.MatriculacionEstudianteRespDto ModificarEstudianteMatriculado(int codigo,Dto.MatriculacionEstudianteDto dto)
        {

            if (String.IsNullOrEmpty(dto.PrimerNombre))
            {
                throw new ApplicationException("El primer nombre es obligatorio");
            }

            if (String.IsNullOrEmpty(dto.PrimerApellido))
            {
                throw new ApplicationException("El primer nombre es obligatorio");
            }

            if (dto.FechaNacimiento > DateTime.UtcNow.AddYears(-18))
            {
                throw new ApplicationException("Debe ser mayor de edad");
            }

            if (!dto.PagoRealizado)
            {
                throw new ApplicationException("Debe realizar el pago previo a maricularse");
            }

            var estudiante = new Estudiante()
            {
                Id = codigo,
                Nombres = String.Concat(dto.PrimerNombre, " ", dto.SegundoNombre).TrimEnd(),
                Apellidos = String.Concat(dto.PrimerApellido, " ", dto.SegundoApellido).TrimEnd(),
                Activo = dto.PagoRealizado,
                FechaNacimiento = dto.FechaNacimiento
            };
            var resultado = repEstudiantes.modificar(estudiante);

            return new Dto.MatriculacionEstudianteRespDto()
            {
                CodigoEstudiante = resultado.Id,
                Nombres = resultado.Nombres,
                Apellidos = resultado.Apellidos,
                FechaMatriculacion = DateTime.UtcNow
            };
        }

        public List<Dto.MatriculacionEstudianteRespDto> ConsultarEstudiantes()
        {

            var estudiantes = repEstudiantes.consultarTodo();
            if (estudiantes == null)
            {
                return new List<Dto.MatriculacionEstudianteRespDto>();
            }
            return estudiantes.Select(e => new Dto.MatriculacionEstudianteRespDto()
            {
                CodigoEstudiante = e.Id,
                Nombres = e.Nombres,
                Apellidos = e.Apellidos,
                FechaMatriculacion = e.FechaNacimiento
            }).ToList();
        }

        public Dto.MatriculacionEstudianteRespDto ConsultarRegistroEstudiante(int codigoEstudiante) {

            var estudiante = repEstudiantes.consultarPorId(codigoEstudiante);
            if (estudiante == null)
            {
                return null;
            }
            return new Dto.MatriculacionEstudianteRespDto() { 
                CodigoEstudiante = estudiante.Id,
                Nombres = estudiante.Nombres,
                Apellidos = estudiante.Apellidos,
                FechaMatriculacion = estudiante.FechaNacimiento
            };
        }

        public void EliminarRegistroEstudiante(int codigoEstudiante)
        {
            repEstudiantes.eliminar(codigoEstudiante);            
        }
    }
}
