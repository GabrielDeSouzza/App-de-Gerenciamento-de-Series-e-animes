using Projeto_CadastroSeries.Classes;
using Projeto_CadastroSeries.Classes.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_CadastroSeries
{
    public class Animes:EntidadeBase
    {
        private List<GeneroAnime> Genero { get; set; }
        private int Ano { get; set; }
        private string Titulo { get; set; }
        private string Destricao { get; set; }
        private bool Excluir { get; set; }

        public Animes(int Id, List<GeneroAnime> Genero, string Titulo,string Descricao, int ano)
        {
            this.Ano = ano;
            this.Titulo = Titulo;
            this.Destricao = Descricao;
            this.Genero = Genero;
            this.Id = Id;
        }
        public override string ToString()
        {
            
            string retorno = "";
            retorno += "Gênero: " +string.Join(" ;", this.Genero.ToArray())+ Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Discrição " + this.Destricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        int retornaID()
        {
            return this.Id;
        }
        public void Exclui()
        {
            this.Excluir = true;
        }
        public List<GeneroAnime> retornaGenero()
        {
            return this.Genero;
        }
    }
}
