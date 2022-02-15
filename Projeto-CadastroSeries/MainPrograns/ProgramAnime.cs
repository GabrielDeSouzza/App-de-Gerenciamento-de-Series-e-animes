using Projeto_CadastroSeries.Utilidades;
using System;
using Projeto_CadastroSeries.Classes.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_CadastroSeries.Classes.Enum;

namespace Projeto_CadastroSeries.MainPrograns
{
    public class ProgramAnime
    {
        static AnimeRepository repository = new AnimeRepository(); 
        public void ProgramAninme()
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
                        PesguisaGenero();
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

        private void PesguisaGenero()
        {
            Console.WriteLine("Escolha entre os Gêneros disponíveis");
            foreach (int numGenero in Enum.GetValues(typeof(GeneroAnime)))
            {
                Console.WriteLine($"{numGenero} = {Enum.GetName(typeof(GeneroAnime), numGenero)}");
            }
            Console.WriteLine("Digite o numero de apenas 1 Gênero");
            int genero;
            if(int.TryParse(Console.ReadLine(),out genero))
            {
                var animesGenerosList = repository.RetornaPorGenero((GeneroAnime)genero);
                if(animesGenerosList.Count > 0)
                foreach (var item in animesGenerosList)
                {
                    Console.WriteLine($"Nome: {item.retornaTitulo()}, Id#{item.Id}");
                }
                else
                {
                    Console.WriteLine("Não há nenhum anime com esse gênero");
                }
            }
            else
            {
                Console.WriteLine("Digite uma opção válida");
                PesguisaGenero();
            }

        }

        private void PesquisaID()
        {
            Console.WriteLine("Digite o Id do Anime");
            int id = int.Parse(Console.ReadLine());
            if (repository.VerificarExistencia(id))
            {
                var anime = repository.RetornaPorId(id);
                Console.WriteLine(anime.ToString());
            }
        }

        private void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID do anime a ser Atualizado");
            int id; 
            if(int.TryParse(Console.ReadLine(), out id)){
                if (repository.VerificarExistencia(id))
                {
                    List<GeneroAnime> animesGeneros;
                    string titulo, descricao;
                    int ano;
                    Atualizar_AddInfo(out animesGeneros, out ano, out descricao, out titulo);

                    Animes UpdateAnime = new Animes(repository.ProximoId(), animesGeneros, titulo, descricao, ano);
                    repository.Atualiza(id, UpdateAnime);
                }
                else
                {
                    Console.WriteLine("Digite um ID válido");
                    AtualizarSerie();
                } 
            }
            else
            {
                Console.WriteLine("Digite um valor válido");
                AtualizarSerie();
            }
        }

        private void ListarSeries()
        {

            var animes =repository.Listar();
            foreach (var anime in animes)
            {
                Console.WriteLine($"Nome: {anime.retornaTitulo()}, ID#{anime.Id}");
            }
        }

        private void InsereSerie()
        {
            List<GeneroAnime> animesGeneros;
            string titulo, descricao;
            int ano;
            Atualizar_AddInfo(out animesGeneros, out ano, out descricao, out titulo);

            Animes newAnime = new Animes(repository.ProximoId(),animesGeneros,titulo,descricao,ano);
            repository.Insere(newAnime);
        }

        private void Atualizar_AddInfo(out List<GeneroAnime> genero,out int ano,out string descricao,out string titulo)
        {
            genero = new List<GeneroAnime>();
            Console.WriteLine("\n\nGenero disposniveis");
            foreach (int numGenero in Enum.GetValues(typeof(GeneroAnime)))
            {
                Console.WriteLine($"{numGenero} = {Enum.GetName(typeof(GeneroAnime), numGenero)}");
            }
            Console.WriteLine("Digite os numeros dos generos que você quer e coloque espaço entre eles");
            Console.WriteLine("Exemplo: 2 5 8");
            string generosEscolhido = Console.ReadLine();
            string[] formandoGeneros = generosEscolhido.Split(' ');
            
            foreach (string generos in formandoGeneros)
            {
                genero.Add((GeneroAnime)Convert.ToInt32(generos));
            }
            Console.WriteLine("Digite o Título do Anime");
            titulo = Console.ReadLine();
            Console.WriteLine("Digite a Descrição");
            descricao = Console.ReadLine();
            Console.WriteLine("Digite o Ano de Lançamento");
            ano = int.Parse(Console.ReadLine());
        }
       
    }
}
