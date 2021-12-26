using System;

namespace DIO.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaousuario = ObterOpcaoUsuario();

            while (opcaousuario.ToUpper() != "x")
            {
                switch (opcaousuario)
                {
                    case '1':
                        ListarSerie();
                        break;
                    case '2':
                        InserirSerie();
                        break;
                    case '3':
                        AtualizarSerie();
                        break;
                    case '4':
                        ExcluirSerie();
                        break;
                    case '5':
                        VisualizarSerie();
                        break;
                    case 'C':
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaousuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano do Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void vizualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetValues(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano do Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie atualizaSerie = new Serie(id: inidiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo,ano: entradaAno, descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }



        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO serie ao seu dispor");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1. Listar Séries");
            Console.WriteLine("2. Inserir nova Série");
            Console.WriteLine("3. Atualizar Série");
            Console.WriteLine("4. Excluir série");
            Console.WriteLine("5. Vizualizar Série");
            Console.WriteLine("C. Limpar Tela");
            Console.WriteLine("X. Sair");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;        
        }
    }
}
