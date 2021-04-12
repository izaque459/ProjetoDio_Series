using System;

namespace DIO_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
             string opcaoUsuario = ObterOpcaoUsuario();

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

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			
        }

         private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorID(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			Temporada temporada;
			foreach (var serie in lista)
			{
                var excluido = serie.RetornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2} ", serie.RetornaID(), serie.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
				for(int i=0; i<serie.NTemporadas(); i++)
				{
					serie.RetornaTemporadas(i, out temporada);
					if(temporada.Degustacao)
						Console.WriteLine("Temporada #{0} Episodios {1} com degustação ",i+1,temporada.Episodios);
					else
						Console.WriteLine("Temporada #{0} Episodios {1}",i+1,temporada.Episodios);
				}
			}
		}

         private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
			Console.Write("Digite o numero de Temporadas: ");
			int entradaTemporadas = int.Parse(Console.ReadLine());
			int entradaNEpisodios = 0;
			int entradaDegustacao = 2;
			bool entradaDegustacaoLogica = false;
			Console.WriteLine("Para cada temporada digite o numero de episodios e  se em alguma há degustação do primeiro episodio.");
			for(int i=0; i<entradaTemporadas; i++)
			{
				Console.WriteLine("Temporada #{0}",i+1);
				Console.Write("Numeros de episodios: ");
				entradaNEpisodios = int.Parse(Console.ReadLine());
				Console.Write("Digite 1 se houver degustacao ou 2 caso não haja: ");
				entradaDegustacao = int.Parse(Console.ReadLine());
				if(entradaDegustacao==1)
					entradaDegustacaoLogica = true;
				else
					entradaDegustacaoLogica = false;

				Temporada novaTemporada = new Temporada(entradaNEpisodios,entradaDegustacaoLogica);

				novaSerie.AdicionaTemporada(novaTemporada);
				
			}

			repositorio.Insere(novaSerie);
		}
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
