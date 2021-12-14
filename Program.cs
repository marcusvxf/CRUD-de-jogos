using DioCRUD.Classes;
using System;
using DioCRUD.Enum;

namespace DioCRUD
{
    internal class Program
    {
        static JogoRepositorio repositorio = new JogoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = "C";

            while (opcaoUsuario.ToUpper() != "X")
            {
                opcaoUsuario = ObterOpcaoUsuario();
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarJogos();
                        break;
                    case "2":
                        InserirJogo();
                        break;
                    case "3":
                        AtualizarJogo();
                        break;
                    case "4":
                        ExcluirJogo();
                        break;
                    case "5":
                        VisualizarJogo();
                        break ;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        private static void ExcluirJogo()
        {
            Console.WriteLine("Digite o id do jogo ");
            int idJogo = int.Parse(Console.ReadLine());

            repositorio.Exclui(idJogo);
        }

        private static void VisualizarJogo()
        {
            Console.WriteLine("Digite o id do jogo");
            int idJogo = int.Parse(Console.ReadLine());

            var jogo = repositorio.ReTornoPorId(idJogo);
            Console.WriteLine(jogo);
        }

        private static void AtualizarJogo()
        {
            Console.WriteLine("Digite o id do Jogo: ");
            int idJogo = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento do jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição do jogo: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Digite a Plataforma que o jogo foi lançado: ");
            string entradaPlataforma = Console.ReadLine();

            Jogo atualizarJogo = new Jogo(id: idJogo,genero: (Genero)entradaGenero,titulo: entradaTitulo,ano: entradaAno,descricao: entradaDescricao,plataforma:entradaPlataforma);

            repositorio.Atualiza(idJogo, atualizarJogo);
        }


        private static void ListarJogos()
        {
            Console.WriteLine("Listar Jogos");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nemhum jogo cadastrado");
                return;
            }
            foreach(var jogo in lista)
            {
                var excluido = jogo.RetornoExcluido();
                Console.WriteLine($"#ID {jogo.RetornoId()}:- {jogo.RetornoTitulo()}" + (excluido ? " *Excluído*" : ""));
            }
        }

        private static void InserirJogo()
        {
            Console.WriteLine("Adicionar novo jogo");
            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}.{System.Enum.GetName(typeof(Genero),i)}");
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do jogo: ");
            String entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento do jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do jogo: ");
            String entradaDescricao = Console.ReadLine();

            Console.WriteLine("Digite as plataformas que o jogo foi lançado: ");
            String entradaPlataforma = Console.ReadLine();

            Jogo novoJogo = new Jogo(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao,plataforma: entradaPlataforma);

            repositorio.Insere(novoJogo);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIo jogos !!!");
            Console.WriteLine("1- Listar jogos");
            Console.WriteLine("2- Inserir novo jogo");
            Console.WriteLine("3- Atualizar jogo");
            Console.WriteLine("4- Excluir jogo");
            Console.WriteLine("5- Visualizar jogo");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
