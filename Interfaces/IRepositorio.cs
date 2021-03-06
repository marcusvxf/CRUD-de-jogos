using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioCRUD.Interfaces
{
    internal interface IRepositorio<T>
    {
        List<T> Lista();

        T ReTornoPorId(int id);

        void Insere(T entidade);

        void Exclui(int id);

        void Atualiza(int id,T entidade);

        int ProximoId();
    }
}
