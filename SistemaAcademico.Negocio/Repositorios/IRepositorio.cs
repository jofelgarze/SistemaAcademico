using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Negocio.Repositorios
{
    public interface IRepositorio<E,K>
    {
        List<E> consultarTodo();
        E consultarPorId(K id);
        E crear(E dato);
        E modificar(E dato);
        void eliminar(K id);
        void eliminar(E dato);

    }
}
