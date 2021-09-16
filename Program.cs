using System;

namespace Cad.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = MenuUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;

                    case "2":
                    InserirSerie();
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
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = MenuUsuario();                 
            }

            Console.WriteLine("Obrigada por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var Lista = repositorio.Lista();
            if (Lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in Lista)
            {
                var excluido = serie.retornaExcluido(); 
                if (!excluido)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
                
            }            
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir novo dorama");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do dorama: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início do dorama: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do dorama: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao); 

            repositorio.Insere(novaSerie);
        }

          private static void AtualizarSerie()
        {
            Console.Write("Digite o id do dorama: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do dorama: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início do dorama: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do dorama: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao); 

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id do dorama: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id do dorama: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string MenuUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Doramas a seu dispor!");
            Console.WriteLine("Escolha a opção desejada:");

            Console.WriteLine("1. Lista de doramas");
            Console.WriteLine("2. Inserir novo dorama");
            Console.WriteLine("3. Atualizar dorama");
            Console.WriteLine("4. Excluir dorama");
            Console.WriteLine("5. Visualizar dorama");
            Console.WriteLine("6. Limpar tela");
            Console.WriteLine("X. Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
