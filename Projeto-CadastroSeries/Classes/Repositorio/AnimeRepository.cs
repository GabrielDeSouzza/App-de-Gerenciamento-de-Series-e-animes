using Projeto_CadastroSeries.Classes.Enum;
using Projeto_CadastroSeries.Classes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_CadastroSeries.Classes.Repositorio
{
    public class AnimeRepository : IRepository<Animes>
    {
        List<Animes> animesList = new List<Animes>();
        public void Atualiza(int id, Animes entidade)
        {
            animesList[id]= entidade;
        }

        public void Exlui(int id)
        {
            animesList[id].Exclui();
        }

        public void Insere(Animes entidade)
        {
            animesList.Add(entidade);
        }

        public List<Animes> Listar()
        {
            return animesList;
        }

        public int ProximoId()
        {
           return animesList.Count();
        }

        public Animes RetornaPorId(int id)
        {
            return animesList[id];
        }
        
        public bool VerificarExistencia(int id)
        {
            if (animesList.Count > id)
                return true;
            return false;
        }
        public List<Animes> RetornaPorGenero(GeneroAnime genero)
        {
            List<Animes> lista = new List<Animes>();
            for(int i = 0; i < animesList.Count; i++)
            {
                foreach(var item in animesList[i].retornaGenero())
                {
                    if (item == genero)
                    {
                        lista.Add(animesList[i]);
                    }
                }
            }
            return lista;
        }
    }
}
