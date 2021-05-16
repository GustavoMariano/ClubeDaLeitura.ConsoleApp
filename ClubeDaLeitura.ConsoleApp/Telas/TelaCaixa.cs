using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaCaixa : TelaBase, ICadastravel
    {
        private ControladorCaixa controladorCaixa;

        public TelaCaixa(string titulo, ControladorCaixa controladorCaixa) : base(titulo)
        {
            this.controladorCaixa = controladorCaixa;
        }

        public override void InserirNovoRegistro()
        {
            Console.Clear();

            string resultadoValidacao = "a";

            while (resultadoValidacao != "Caixa cadastrada com sucesso!!")
            {
                resultadoValidacao = (GravarCaixa(0));
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                Console.Clear();
            }
        }

        public override void VisualizarRegistros()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-20} | {2,-35} | {3,-40}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();

            for (int i = 0; i < caixas.Length; i++)
            {
                Console.Write(configuracaColunasTabela, caixas[i].Id, caixas[i].Cor, caixas[i].Numero, caixas[i].Etiqueta);

                Console.WriteLine();
            }

            if (caixas.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhuma caixa cadastrada!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public override void EditarRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja editar: ");
            int idSelecionado;
            Int32.TryParse(Console.ReadLine(), out idSelecionado);

            int idExitente = controladorCaixa.VerificaId(idSelecionado);

            if (idExitente == 0)
            {
                Console.WriteLine("Id não encontrado, tente novamente!!");
                Console.ReadLine();
            }
            else
            {
                string resultadoValidacao = "a";

                resultadoValidacao = (GravarCaixa(idSelecionado));

                if(resultadoValidacao == "Caixa cadastrada com sucesso!!")
                {
                    Console.WriteLine("Caixa editada com sucesso");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                    Console.WriteLine(resultadoValidacao);                
            }
        }

        public override void ExcluirRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja excluir: ");
            int idSelecionado;
            Int32.TryParse(Console.ReadLine(), out idSelecionado);

            int idExitente = controladorCaixa.VerificaId(idSelecionado);

            if (idExitente == 0)
            {
                Console.WriteLine("Id não encontrado, tente novamente!!");
                Console.ReadLine();
            }
            else
            {
                bool conseguiuExcluir = controladorCaixa.ExcluirCaixa(idSelecionado);

                if (conseguiuExcluir)
                {
                    Console.WriteLine("Registro excluído com sucesso");
                    Console.ReadLine();
                }
            }
        }

        private string GravarCaixa(int id)
        {
            string resultadoValidacao;

            Console.WriteLine("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.WriteLine("Digite o numero da caixa: ");
            int numero;
            bool validaNumero = Int32.TryParse(Console.ReadLine(), out numero);

            if (validaNumero == false)
                return resultadoValidacao = "O campo número não foi preenchido com um inteiro, tente novamente!!";
            else
            {
                Console.WriteLine("Digite a etiqueta da caixa: ");
                string etiqueta = Console.ReadLine();

                resultadoValidacao = controladorCaixa.RegistrarCaixa(id, cor, numero, etiqueta);

                if (resultadoValidacao == "CAIXA_VALIDA")
                    return "Caixa cadastrada com sucesso!!";
                else
                    return resultadoValidacao;
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Cor", "Numero", "Etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
