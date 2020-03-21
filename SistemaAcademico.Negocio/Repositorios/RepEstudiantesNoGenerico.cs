using SistemaAcademico.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Negocio.Repositorios
{
    class RepEstudiantesNoGenerico : IRepositorioNoGenerico
    {
        private AcademiaContextoDb _contextoDb;

        public RepEstudiantesNoGenerico(AcademiaContextoDb contextoDb)
        {
            this._contextoDb = contextoDb;
        }

        public object consultarPorId(object id)
        {
            int _id = (int)id;

            var estudiante = _contextoDb.Estudiantes.Where(e => e.Id == _id).FirstOrDefault();

            return estudiante;
        }

        public List<object> consultarTodo()
        {
            throw new NotImplementedException();
        }

        public object crear(object dato)
        {
            throw new NotImplementedException();
        }

        public void eliminar(object dato)
        {
            throw new NotImplementedException();
        }

        public object modificar(object dato)
        {
            throw new NotImplementedException();
        }
    }
}
