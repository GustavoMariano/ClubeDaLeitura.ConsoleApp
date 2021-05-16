using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaRevista : TelaBase, ICadastravel
    {
        private ControladorRevista controladorRevista;
        private TelaCaixa telaCaixa;
        private ControladorCaixa controladorCaixa;

        public TelaRevista(string titulo, ControladorRevista controladorRevista, TelaCaixa telaCaixa, ControladorCaixa controladorCaixa) : base(titulo)
        {
            this.controladorRevista = controladorRevista;
            this.telaCaixa = telaCaixa;
            this.controladorCaixa = controladorCaixa;
        }

        public override void InserirNovoRegistro()
        {
            Console.Clear();

            string resultadoValidacao = "a";

            while (resultadoValidacao != "Revista cadastrada com sucesso!!")
            {
                resultadoValidacao = (GravarRevista(0));
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                Console.Clear();
            }
        }

        public override void VisualizarRegistros()
        {
            Console.Clear();

            MontarCabecalhoTabela();

            Revista[] revistas = (Revista[])controladorRevista.SelecionarTodasRevistas();

            foreach (Revista revista in revistas)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-25} | {3,-25} | {4,-30}",
                    revista.Id, revista.Caixa.Etiqueta, revista.Edicao, revista.Ano.ToString("yyyy"), revista.Colecao);
            }

            if (revistas.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum chamado registrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public override void EditarRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.Write("Digite o Id da revista que deseja editar: ");
            int idSelecionado;
            Int32.TryParse(Console.ReadLine(), out idSelecionado);

            Console.Clear();

            int idExitente = controladorRevista.VerificaId(idSelecionado);

            if (idExitente == 0)
            {
                Console.WriteLine("Id não encontrado, tente novamente!!");
                Console.ReadLine();
            }
            else
                GravarRevista(idSelecionado);
        }

        public override void ExcluirRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o Id da revista que deseja excluir: ");
            int idSelecionado;
            Int32.TryParse(Console.ReadLine(), out idSelecionado);            

            int idExitente = controladorRevista.VerificaId(idSelecionado);

            if (idExitente == 0)
            {
                Console.WriteLine("Id não encontrado, tente novamente!!");
                Console.ReadLine();
            }
            else
            {
                bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);

                if (conseguiuExcluir)
                {
                    Console.WriteLine("Registro excluído com sucesso");
                    Console.ReadLine();
                }
            }
        }

        private string GravarRevista(int id)
        {
            string resultadoValidacao;

            telaCaixa.VisualizarRegistros();

            Console.Write("Digite o Id da caixa que a revista ficará: ");
            int idCaixaSelecionada;
            Int32.TryParse(Console.ReadLine(), out idCaixaSelecionada);

            int idExitente = controladorCaixa.VerificaId(idCaixaSelecionada);

            if (idExitente == 0)
            {
                return "Id não encontrado, tente novamente!!";
            }
            else
            {
                Console.Write("Digite a edição da revista: ");
                string edicao = Console.ReadLine();

                Console.Write("Digite a coleção da revista: ");
                string colecao = Console.ReadLine();

                Console.Write("Digite o ano de publicação da revista: ");
                int ano;
                Int32.TryParse(Console.ReadLine(),out ano);

                resultadoValidacao = controladorRevista.RegistrarRevista(id, idCaixaSelecionada,
                    edicao, colecao, ano);

                if (resultadoValidacao == "REVISTA_VALIDA")
                    return "Revista cadastrada com sucesso!!";
                else
                    return resultadoValidacao;
            }
        }

        private static void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-25} | {3,-25} | {4,-30}", "Id", "Etiqueta da Caixa", "Edição", "Ano", "Coleção");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
