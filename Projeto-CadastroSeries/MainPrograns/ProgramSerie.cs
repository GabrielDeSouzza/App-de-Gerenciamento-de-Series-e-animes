using Projeto_CadastroSeries.Classes;
using Projeto_CadastroSeries.Classes.Repositorio;
using Projeto_CadastroSeries.Utilidades;
using System;

namespace Projeto_CadastroSeries.MainPrograns
{
    public class ProgramSerie
    {
        static SerieRepository repository = new SerieRepository();
        public ProgramSerie()
        {

            string OpcaoUsuario;

        inicio:

            ModeloMenu menu = new ModeloMenu();
            menu.Menu(out OpcaoUsuario);

            while (OpcaoUsuario.ToLower() != "x")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        InsereSerie();
                        break;
                    case "2":
                        ListarSeries();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        PesquisaID();
                        break;
                    case "5":
                        PesguinaGenero();
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente");
                        goto inicio;
                }
                goto inicio;
            }
            Console.WriteLine("\n\n\n\t\t\t\t Até a proxíma!!!");
        }

        //Opçãoes do menu
        static void InsereSerie()
        {
            int genero, ano;
            string titulo, descricao;
            Add_AtualizarInfo(out genero, out ano, out titulo, out descricao);

            Series newSerie = new Series(repository.ProximoId(), Genero: (Genero)genero, titulo, descricao, ano);

            repository.Insere(newSerie);

            Console.WriteLine("Série Inserida com Sucesso!!\n\n");
        }
        static void ListarSeries()
        {
            Console.WriteLine("Series já cadastradas");

            if (repository.Listar().Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastradasta");
            }
            else
            {
                foreach (var item in repository.Listar())
                {
                    Console.WriteLine($"Nome: {item.retornaTitulo()}, Id #{item.Id}");
                }
            }

        }

        static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da Serie");
            int SerieiId;
        inicio:
            if (Int32.TryParse(Console.ReadLine(), out SerieiId) == false)
            {
                Console.WriteLine("Digite um valor válido");
                goto inicio;
            }
            else
            {
                if (repository.VerificarExistencia(SerieiId))
                {
                    int genero, ano;
                    string titulo, descricao;
                    Add_AtualizarInfo(out genero, out ano, out titulo, out descricao);
                    Series atualizarSerie = new Series(SerieiId, Genero: (Genero)genero, titulo, descricao, ano);
                    repository.Atualiza(SerieiId, atualizarSerie);
                    Console.WriteLine("Série Atualizada com sucesso");
                }
                else
                {
                    Console.WriteLine("Série não encontrada, verifique se o ID digitado esta correto");
                    AtualizarSerie();
                }
            }

        }

        static void PesquisaID()
        {
            Console.WriteLine("\n\n Digite o ID da série");
            int id = Convert.ToInt32(Console.ReadLine());
            if (repository.VerificarExistencia(id))
            {
                var seriePesquisada = repository.RetornaPorId(id);
                Console.WriteLine(seriePesquisada.ToString());
            }
            else
            {
                Console.WriteLine("ID digitado não é válido, tente novamente");
                PesquisaID();
            }
        }

        static void PesguinaGenero()
        {
            Console.WriteLine("\n\nGenero disposniveis");
            foreach (int numGenero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{numGenero} = {Enum.GetName(typeof(Genero), numGenero)}");
            }
            Console.WriteLine("Digite o numero do genero desejavel");
            int genero = Convert.ToInt32(Console.ReadLine());

        }

        static void ExcluirSerie()
        {
            Console.WriteLine("\n\nDigite o ID da série que sera excluida");
            int id = Convert.ToInt32(Console.ReadLine());
            if (repository.VerificarExistencia(id))
            {
                repository.Exlui(id);
                Console.WriteLine("Série excluida com sucesso");
            }
            else
            {
                Console.WriteLine("ID digitado não é válido, tente novamente");
                ExcluirSerie();
            }
        }
        //Utilidades
        static void Add_AtualizarInfo(out int genero, out int ano, out string descricao, out string titulo)
        {
            Console.WriteLine("\n\nGenero disposniveis");
            foreach (int numGenero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{numGenero} = {Enum.GetName(typeof(Genero), numGenero)}");
            }
            Console.WriteLine("Digite o numero do genero desejavel");
            genero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n\nDigite o Titulo da Serie");
            titulo = Console.ReadLine();

            Console.WriteLine("\n\nDIgite uma destrição da Serie");
            descricao = Console.ReadLine();

            Console.WriteLine("\n\nDigite o ano de lançamento da serie");
            ano = int.Parse(Console.ReadLine());
        }
    }
}
