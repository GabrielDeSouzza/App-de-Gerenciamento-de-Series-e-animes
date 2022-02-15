using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_CadastroSeries.Classes.Interface
{
    public interface IRepository<T>
    {
        List<T> Listar();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exlui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}
