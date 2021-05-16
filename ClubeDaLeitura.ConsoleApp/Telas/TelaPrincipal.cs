using System;
using ClubeDaLeitura.ConsoleApp.Controladores;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    class TelaPrincipal : TelaBase
    {
        static int CAPACIDADE_REGISTROS = 100;

        static ControladorCaixa controladorCaixa = new ControladorCaixa(CAPACIDADE_REGISTROS);
        static ControladorAmiguinho controladorAmiguinho = new ControladorAmiguinho(CAPACIDADE_REGISTROS);
        static ControladorRevista controladorRevista = new ControladorRevista(CAPACIDADE_REGISTROS, controladorCaixa);
        static ControladorEmprestimo controladorEmprestimo = new ControladorEmprestimo(CAPACIDADE_REGISTROS, controladorAmiguinho, controladorRevista);
        static TelaCaixa telaCaixa = new TelaCaixa("Controle de caixas\n-------------------\n", controladorCaixa);
        static TelaRevista telaRevista = new TelaRevista("Controle de revistas\n---------------------\n", controladorRevista, telaCaixa, controladorCaixa);
        static TelaAmiguinho telaAmiguinho = new TelaAmiguinho("Controle de amiguinhos\n-----------------------\n", controladorAmiguinho);
        static TelaEmprestimo telaEmprestimo = new TelaEmprestimo("Controle de emprestimos\n------------------------\n", telaRevista, telaAmiguinho, controladorEmprestimo, controladorRevista, controladorAmiguinho);

        public TelaPrincipal(string titulo) : base(titulo) { }

        public TelaBase ObterOpcao(string titulo)
        {
            TelaBase telaSelecionada = null;
            string opcao;
            do
            {
                Console.WriteLine(titulo + "\n---------------\n");

                Console.WriteLine("Digite 1 para o Controle de Amiguinhos");
                Console.WriteLine("Digite 2 para o Controle de Emprestimos");
                Console.WriteLine("Digite 3 para o Controle de Revistas");
                Console.WriteLine("Digite 4 para o Controle de Caixas");
                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine().ToUpper();

                if (opcao == "1")
                {
                    TelaAmiguinho tela = telaAmiguinho;
                    return tela;
                }
                else if (opcao == "2")
                {
                    TelaEmprestimo tela = telaEmprestimo;
                    return tela;
                }
                else if (opcao == "3")
                {
                    TelaRevista tela = telaRevista;
                    return tela;
                }
                else if (opcao == "4")
                {
                    TelaCaixa tela = telaCaixa;
                    return tela;
                }
                else if (opcao.Equals("S"))
                {
                    Environment.Exit(0);
                }

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S")
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
                Console.Clear();
                return true;
            }
            else
                return false;
        }
    }
}
