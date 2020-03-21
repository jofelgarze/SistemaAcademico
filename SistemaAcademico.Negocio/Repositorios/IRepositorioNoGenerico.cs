using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Negocio.Repositorios
{
    interface IRepositorioNoGenerico
    {
        List<object> consultarTodo();
        object consultarPorId(object id);
        object crear(object dato);
        object modificar(object dato);
        void eliminar(object dato);
    }
}
