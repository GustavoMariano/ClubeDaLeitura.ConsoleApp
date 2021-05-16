using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaAmiguinho : TelaBase, ICadastravel
    {
        private  ControladorAmiguinho controladorAmiguinho;

        public TelaAmiguinho(string titulo, ControladorAmiguinho controladorAmiguinho) : base(titulo)
        {
            this.controladorAmiguinho = controladorAmiguinho;
        }

        public override void InserirNovoRegistro()
        {
            Console.Clear();

            string resultadoValidacao = "a";

            while (resultadoValidacao != "Amiguinho cadastrado com sucesso!!")
            {
                resultadoValidacao = (GravarAmiguinho(0));
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                Console.Clear();
            }            
        }

        public override void EditarRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            int idSelecionado;
            Console.Write("Digite o número do amiguinho que deseja editar: ");
            Int32.TryParse(Console.ReadLine(), out idSelecionado);

            int idExitente = controladorAmiguinho.VerificaId(idSelecionado);

            if(idExitente == 0)
            {
                Console.WriteLine("Id não encontrado, tente novamente!!");
                Console.ReadLine();
            }
            else
                GravarAmiguinho(idSelecionado);
        }

        public override void ExcluirRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do amiguinho que deseja excluir: ");
            int idSelecionado;
            Int32.TryParse(Console.ReadLine(), out idSelecionado);

            int idExitente = controladorAmiguinho.VerificaId(idSelecionado);

            if (idExitente == 0)
            {
                Console.WriteLine("Id não encontrado, tente novamente!!");
                Console.ReadLine();
            }
            else
            {
                bool conseguiuExcluir = controladorAmiguinho.ExcluirAmiguinho(idSelecionado);

                if (conseguiuExcluir)
                {
                    Console.WriteLine("Registro excluído com sucesso");
                    Console.ReadLine();
                }
            }                
        }

        public override void VisualizarRegistros()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-30} | {2,-25} | {3,-25} | {4,-30}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amiguinho[] amiguinho = (Amiguinho[])controladorAmiguinho.SelecionarTodosAmiguinhos();

            for (int i = 0; i < amiguinho.Length; i++)
            {
                Console.Write(configuracaColunasTabela, amiguinho[i].Id, amiguinho[i].Nome,
                    amiguinho[i].Telefone, amiguinho[i].DeOndeEh, amiguinho[i].Responsavel);

                Console.WriteLine();
            }

            if (amiguinho.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum amiguihno cadastrado!");
                Console.ResetColor();
            }
            Console.ReadLine();
        }

        private string GravarAmiguinho(int id)
        {
            Console.WriteLine("Digite o nome do amiguinho: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o telefone do amiguinho: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite de onde é o amiguinho: ");
            string deOndeEh = Console.ReadLine();

            Console.WriteLine("Digite o nome do responsavel do amiguinho: ");
            string responsavel = Console.ReadLine();

            string resultadoValidacao = controladorAmiguinho.RegistrarAmiguinho(id, nome, telefone, deOndeEh, responsavel);
            if (resultadoValidacao == "AMIGUINHO_VALIDO")
                return "Amiguinho cadastrado com sucesso!!";
            else
                return resultadoValidacao;
        }


        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Telefone", "De onde é", "Resposável");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
