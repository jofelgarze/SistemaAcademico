using SistemaAcademico.Datos;
using SistemaAcademico.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Negocio.Repositorios
{
    class RepEstudiantes : IRepositorio<Estudiante, Int32>
    {
        private AcademiaContextoDb _contextoDb;

        public RepEstudiantes(AcademiaContextoDb contextoDb)
        {
            this._contextoDb = contextoDb;
        }

        public Estudiante consultarPorId(int id)
        {
            var estudiante = _contextoDb.Estudiantes.Where(e => e.Id == id).FirstOrDefault();

            /*
             * Equivalente a lo anterior
            foreach (var e in _contextoDb.Estudiantes.ToList()) {
                if (e.Id == id)
                {
                    estudiante = e;
                    break;
                }
            }*/

            return estudiante;
        }

        public List<Estudiante> consultarTodo()
        {
            return _contextoDb.Estudiantes.ToList();
        }

        public Estudiante crear(Estudiante dato)
        {
            _contextoDb.Estudiantes.Add(dato);

            //Normalmente estaria fuera del repositorio, 
            //para mantener una suerte de transaccionabilidad
            _contextoDb.SaveChanges();


            return dato;
        }

        public void eliminar(int id)
        {
            var estudiante = consultarPorId(id);
            eliminar(estudiante);
        }

        public void eliminar(Estudiante dato)
        {
            _contextoDb.Estudiantes.Remove(dato);
            _contextoDb.SaveChanges();
        }

        public Estudiante modificar(Estudiante dato)
        {
            var original = consultarPorId(dato.Id);

            original.Nombres = dato.Nombres;
            original.Apellidos = dato.Apellidos;
            original.Activo = dato.Activo;
            original.FechaNacimiento = dato.FechaNacimiento;

            _contextoDb.SaveChanges();

            return original;
        }
    }
}
