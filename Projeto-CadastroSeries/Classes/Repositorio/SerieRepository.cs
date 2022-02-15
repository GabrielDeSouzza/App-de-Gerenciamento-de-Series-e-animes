using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_CadastroSeries.Classes.Interface;

namespace Projeto_CadastroSeries.Classes.Repositorio
{
    internal class SerieRepository : IRepository<Series>
    {
        private List<Series> seriesList = new List<Series>();
        public void Atualiza(int id, Series entidade)
        {
            seriesList[id] = entidade;
        }

        public void Exlui(int id)
        {
            seriesList[id].Exclui();
        }

        public void Insere(Series entidade)
        {
            seriesList.Add(entidade);
        }

        public List<Series> Listar()
        {
            return seriesList;
        }

        public int ProximoId()
        {
            return seriesList.Count;
        }

        public Series RetornaPorId(int id)
        {
           return seriesList[id];
        }

        public bool VerificarExistencia(int id)
        {
            if (seriesList.Count < id)
            {
                return false;
            }
            return true;
        }
    }
}
