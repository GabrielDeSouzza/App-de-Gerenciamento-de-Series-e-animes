using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_CadastroSeries.Utilidades
{
    public class ModeloMenu
    {
        public virtual string Menu(out string OpcaoUsuario)
        {
            Console.WriteLine("Escolha uma das opções abaixo\n\n");
            Console.WriteLine("1-Inserir  Serie");
            Console.WriteLine("2-Listar Series");
            Console.WriteLine("3-Atulizar Serie");
            Console.WriteLine("4-Pesquisar Serie por ID");
            Console.WriteLine("5-Pesquisar por Genero");
            Console.WriteLine("6-Exluir Série");
            Console.WriteLine("Digite x para sair");
            OpcaoUsuario = Console.ReadLine();
            return OpcaoUsuario;
        }
    }
}
