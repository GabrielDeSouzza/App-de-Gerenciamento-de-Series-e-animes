using Projeto_CadastroSeries.Classes;
using Projeto_CadastroSeries.Classes.Repositorio;
using Projeto_CadastroSeries.MainPrograns;
using System;

namespace Projeto_CadastroSeries
{
    internal class Program
    {  
        static void Main(string[] args)
        {
            string opcaoUsuario;
            Console.WriteLine("\t\t\tBem Vindo ao Mundo Series/Animes\n\n\n");
            Console.WriteLine("Colha uma das opções abaixo");
            Console.WriteLine("Digite 1- para Series");
            Console.WriteLine("DIgite 2 para Animes");
            opcaoUsuario = Console.ReadLine();
            switch (opcaoUsuario){
                case "1":
                    ProgramSerie programSerie = new ProgramSerie();
                    Main(args);
                    break;
                case "2":
                    ProgramAnime programAnime = new ProgramAnime();
                    programAnime.ProgramAninme();
                    Main(args);
                    break;
                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }
        }

    }
        

    
}
