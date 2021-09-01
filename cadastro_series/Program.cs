using System;
using cadastro_series.Classes;
using cadastro_series.Enum;

namespace cadastro_series
{
    class Program
    {
        static SerieRepository serie_repository = new SerieRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while( opcaoUsuario.ToUpper() != "X" )
            {
                switch( opcaoUsuario )
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        CadastrarSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        System.Console.WriteLine("Digite um número válido");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar a aplicação");
            System.Console.WriteLine();
        }

        private static void ListarSerie() 
        {
            System.Console.WriteLine("Lista de séries");

            var lista = serie_repository.Listar();

            if ( lista.Count == 0 ) {

                System.Console.WriteLine("Nehuma série encontrada");
                return;
            }

            foreach ( var serie in lista )
            {
                var excluido = serie.returnExcluido();

                if ( !excluido ) {
                    System.Console.WriteLine($"#ID: {serie.retornaId()}: - {serie.retornaTitulo()} ");
                }
            }
        }
        
        private static void CadastrarSerie()
        {
            System.Console.WriteLine("Cadastre uma nova série");

            foreach ( int i in Genero.GetValues(typeof(Genero)) )
            {
                System.Console.WriteLine($"{i} - {Genero.GetName(typeof(Genero), i)}");
            }

            System.Console.Write("Digite um gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string titulo = Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento da série: ");
            int ano = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string descricao = Console.ReadLine();

            Series novaSerie = new Series(id: serie_repository.ProximoId(),
                                            genero: (Genero)genero,
                                            titulo: titulo,
                                            ano: ano,
                                            descricao: descricao);

            serie_repository.Cadastrar(novaSerie);
        }

        private static void AtualizarSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            foreach ( int i in Genero.GetValues(typeof(Genero)) )
            {
                System.Console.WriteLine($"{i} - {Genero.GetName(typeof(Genero), i)}");
            }

            System.Console.Write("Digite um gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string titulo = Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento da série: ");
            int ano = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string descricao = Console.ReadLine();

            Series serie_atualizada = new Series(id: indiceSerie,
                                            genero: (Genero)genero,
                                            titulo: titulo,
                                            ano: ano,
                                            descricao: descricao);

            serie_repository.Atualizar( serie_atualizada, indiceSerie );
        }

        private static void ExcluirSerie() 
        {
            System.Console.Write("Digite o id da série: ");
            int id = int.Parse(Console.ReadLine());

            serie_repository.Deletar(id);
        }

        private static void VisualizarSerie()
        {
            System.Console.Write("digite o id da série: ");
            int id = int.Parse(Console.ReadLine());

            var serie = serie_repository.GetById(id);

            System.Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Cadastre suas séries aqui");
            System.Console.WriteLine("Informe a opção desejada");

            System.Console.WriteLine("1 - Listar séries");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("C - limpar tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }    
}
