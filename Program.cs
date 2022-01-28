//APP de cadastro de desenhos educativos com intuito de ensinar disciplinas escolares para crianças
//classificadas por indicação de serie escolar e por matéria.
using System;

namespace cad_series.Desenhos
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
						ListarDesenhos();
						break;
					case "2":
						InserirDesenhos();
						break;
					case "3":
						AtualizarDesenhos();
						break;
					case "4":
						RemoverDesenhos();
						break;
					case "5":
						VerDesenhos();
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
			Console.ReadLine();
        }

        private static void RemoverDesenhos()
		{
			Console.Write("Digite o identificar da série: ");
			int indiceDesenho = int.Parse(Console.ReadLine());

			repositorio.Remove(indiceDesenho);
		}

        private static void VerDesenhos()
		{
			Console.Write("Digite o id da série: ");
			int indiceDesenho = int.Parse(Console.ReadLine());

			var desenho = repositorio.RetornaPorId(indiceDesenho);

			Console.WriteLine(desenho);
		}

        private static void AtualizarDesenhos()
		{
			Console.Write("Digite o id do desenho: ");
			int indiceDesenho = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Materia)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Materia), i));
			}
			Console.Write("Digite a matéria entre as opções acima: ");
			int entradaMateria = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Desenho: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano escolar do desenho: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a assunto do desenho: ");
			string entradaAssunto = Console.ReadLine();

			Desenhos atualizaDesenho = new Desenhos(id: indiceDesenho,
										materia: (Materia)entradaMateria,
										titulo: entradaTitulo,
										anoEscolar: entradaAno,
										assunto: entradaAssunto);

			repositorio.Atualiza(indiceDesenho, atualizaDesenho);
		}
        private static void ListarDesenhos()
		{
			Console.WriteLine("Listar desenhos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum desenho cadastrado.");
				return;
			}

			foreach (var desenho in lista)
			{
                var excluido = desenho.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", desenho.retornaId(), desenho.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirDesenhos()
		{
			Console.WriteLine("Inserir um novo desenho");

			foreach (int i in Enum.GetValues(typeof(Materia)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Materia), i));
			}
			Console.Write("Digite a materia entre as opções acima: ");
			int entradaMateria = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do desenho: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano escolar do desenho: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a assunto do desenho: ");
			string entradaAssunto = Console.ReadLine();

			Desenhos novoDesenho = new Desenhos(id: repositorio.ProximoId(),
										materia: (Materia)entradaMateria,
										titulo: entradaTitulo,
										anoEscolar: entradaAno,
										assunto: entradaAssunto);

			repositorio.Insere(novoDesenho);
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