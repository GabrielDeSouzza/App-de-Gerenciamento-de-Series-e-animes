using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_CadastroSeries.Classes
{
    public class Series : EntidadeBase
    {
        private Genero Genero { get; set; }
        private int Ano { get; set; }
        private string Titulo { get; set; }
        private string Destricao { get; set; }
        private bool Excluir { get; set; }

        public  Series(int Id, Genero Genero,string Titulo, string Destricao, int Ano)
        {
            this.Id = Id;
            this.Genero = Genero;
            this.Titulo = Titulo;
            this.Destricao = Destricao;
            this.Ano = Ano;
            this.Excluir = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
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
            this.Excluir=true;
        }
    }

    
}
