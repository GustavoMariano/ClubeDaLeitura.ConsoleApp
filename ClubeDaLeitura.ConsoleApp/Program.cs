using System;
using ClubeDaLeitura.ConsoleApp.Telas;

namespace ClubeDaLeitura.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            Console.Clear();

            while (true)
            {

                TelaBase telaSelecionada = (TelaBase)telaPrincipal.ObterOpcao();

                if (telaSelecionada == null)
                    break;

                string opcao = "";

                Console.Clear();

                if (telaSelecionada is ICadastravel)
                {
                    opcao = telaSelecionada.ObterOpcao();

                    if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    switch (opcao)
                    {
                        case "1": telaSelecionada.InserirNovoRegistro(); break;
                        case "2": telaSelecionada.VisualizarRegistros(); break;
                        case "3": telaSelecionada.EditarRegistro(); break;
                        case "4": telaSelecionada.ExcluirRegistro(); break;
                        default:
                            break;
                    }
                }
                else if (telaSelecionada is ICadastravel == false)
                {
                    TelaEmprestimo telaEmprestimo = (TelaEmprestimo)telaSelecionada;

                    opcao = telaEmprestimo.ObterOpcoes();

                    if (opcao == "1")
                        telaEmprestimo.RegistraEmprestimo();

                    else if (opcao == "2")
                        telaEmprestimo.RegistrarDevolucao();

                    else if (opcao == "3")
                        telaEmprestimo.MostrarEmprestimosAbertos();

                    else if (opcao == "4")
                        telaEmprestimo.MostrarEmprestimosPorMes();

                }
                Console.Clear();
            }
        }
    }
}
