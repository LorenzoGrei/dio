using System;
using Dio.Animes;

namespace DIO.Animes
{
    class Program
    {
        static AnimesRepositorio repositorio = new AnimesRepositorio();
         
        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario();
          while (opcaoUsuario.ToUpper() != "X")
          {
              switch (opcaoUsuario)
              {
                  case "1":
                       ListarAnimes();
                       break;
                  case "2":
                       InserirAnimes();
                       break;
                  case "3":
                       AtualizarAnimes();
                       break;
                  case "4":
                        ExcluirAnimes();
                       break;
                  case "5":
                       VisualizarAnimes();
                       break;
                  case "C":
                       Console.Clear();
                       break;

  
                  default:
                        throw new ArgumentOutOfRangeException();     

              }

              opcaoUsuario = ObterOpcaoUsuario();
          }
          Console.WriteLine("Obrigado por utilizar meus serviços.");
          Console.ReadLine();         
            
        }
        private static void ListarAnimes()
        {
            Console.WriteLine ("Listar Animes");
            var lista = repositorio.lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Anime cadastrado.");
                return;
            }
            
            foreach (var animes in lista)
            {
                var Excluido = animes.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}'", animes.retornaId(), animes.retornaTitulo(), (Excluido ? "*Excluido*" : ""));
            }

        }
        private static void ExcluirAnimes()
        { 
            Console.WriteLine("Digite o Id do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceAnime);
        
        }
        private static void VisualizarAnimes()
        {
            Console.WriteLine("Digite o Id do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            var animes = repositorio.RetonrnaPorId(indiceAnime);

            Console.WriteLine(animes);
        }
            

        private static void AtualizarAnimes()
        {
            Console.WriteLine("Digite o Id do Animes: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine ("{0}-{1}", i, Enum.GetName(typeof(Genero),i ));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo do Anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de inicio do Anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição do Anime");
            string entradaDescricao = Console.ReadLine();

            Anime atualizaAnime = new Anime(id: indiceAnime,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceAnime, atualizaAnime);
        }            

        private static void InserirAnimes()
        {
            Console.WriteLine("Inserir novo Anime");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine ("{0}-{1}", i, Enum.GetName(typeof(Genero),i ));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Animes: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de inicio da Animes: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Animes");
            string entradaDescricao = Console.ReadLine();

            Anime novaAnime = new Anime(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaAnime);
        }    





        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Animes ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listar Animes");
            Console.WriteLine("2- Inserir novo Animes");
            Console.WriteLine("3- Atualizar Animes");
            Console.WriteLine("4- Excluir Animes");
            Console.WriteLine("5- Visualizar Animes");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    

    }
}


