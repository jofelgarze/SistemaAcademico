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
    public class UtMatriculacion
    {
        private IRepositorio<Estudiante, Int32> repEstudiantes;
        private AcademiaContextoDb _contextoDb;
        public UtMatriculacion()
        {
            _contextoDb = new AcademiaContextoDb();
            repEstudiantes = new RepEstudiantes(_contextoDb);
        }

        public Dto.MatriculacionEstudianteRespDto MatricularEstudianteNuevo(Dto.MatriculacionEstudianteDto dto) {

            if (String.IsNullOrEmpty(dto.PrimerNombre))
            {
                throw new ApplicationException("El primer nombre es obligatorio");
            }

            if (String.IsNullOrEmpty(dto.PrimerApellido))
            {
                throw new ApplicationException("El primer nombre es obligatorio");
            }

            if (dto.FechaNacimiento < DateTime.UtcNow.AddYears(-18))
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

    }
}
