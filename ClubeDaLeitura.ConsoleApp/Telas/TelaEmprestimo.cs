using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    class TelaEmprestimo : TelaBase
    {
        private TelaRevista telaRevista;
        private TelaAmiguinho telaAmiguinho;
        private ControladorEmprestimo controladorEmprestimo;
        private ControladorRevista controladorRevista;
        private ControladorAmiguinho controladorAmiguinho;

        public TelaEmprestimo(TelaRevista telaRevista, TelaAmiguinho telaAmiguinho, ControladorEmprestimo controladorEmprestimo,
            ControladorRevista controladorRevista, ControladorAmiguinho controladorAmiguinho)
        {
            this.telaRevista = telaRevista;
            this.telaAmiguinho = telaAmiguinho;
            this.controladorEmprestimo = controladorEmprestimo;
            this.controladorRevista = controladorRevista;
            this.controladorAmiguinho = controladorAmiguinho;
        }

        internal void RegistraEmprestimo()
        {
            telaRevista.VisualizarRegistros();

            Console.WriteLine("Digite o número da Id da revista que deseja emprestar: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            int idExitente = controladorRevista.VerificaId(idRevista);

            if (idExitente == 0)
            {
                Console.WriteLine("Id não encontrado, tente novamente!!");
                Console.ReadLine();
            }
            else if (controladorEmprestimo.VerificaEmprestimoRevista(idRevista))
            {
                Console.WriteLine("Esta revista já está emprestada!");
                return;
            }
            else
            {
                telaAmiguinho.VisualizarRegistros();

                Console.WriteLine("Digite o número da Id do amiguinho que deseja efetuar emprestimo: ");
                int idAmiguinho = Convert.ToInt32(Console.ReadLine());

                idExitente = controladorAmiguinho.VerificaId(idAmiguinho);

                if (idExitente == 0)
                {
                    Console.WriteLine("Id não encontrado, tente novamente!!");
                    Console.ReadLine();
                }
                else if (controladorEmprestimo.VerificarEmprestimoAmiguinho(idAmiguinho))
                {
                    Console.WriteLine("O amiguinho ainda não encerrou seu último empréstimo");
                    return;
                }
                else
                {
                    controladorEmprestimo.RegistrarEmprestimo(0, idAmiguinho, idRevista);

                    Console.WriteLine("Emprestimo registrado com sucesso!");
                }
            }
        }

        internal void RegistrarDevolucao()
        {
            Console.Clear();
            MostrarEmprestimosAbertos();

            Console.WriteLine("Digite a id do emprestimo que deseja registrar devolução: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            int idExitente = controladorEmprestimo.VerificaId(idSelecionado);

            if (idExitente == 0)
            {
                Console.WriteLine("Id não encontrado, tente novamente!!");
                Console.ReadLine();
            }
            else
            {

                Emprestimo emprestimo;

                emprestimo = controladorEmprestimo.SelecionarEmprestimoPorId(idSelecionado);

                emprestimo.Status = false;

                Console.WriteLine("Devolução registrada com sucesso!");
            }
        }

        internal void MostrarEmprestimosAbertos()
        {
            Emprestimo[] emprestimo = controladorEmprestimo.SelecionarTodosEmprestimos();

            int contador = 0;

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].Status)
                    contador++;
            }
            Console.WriteLine($"\n{contador} emprestimos abertos.\n");

            string configuracaColunasTabela = "{0,-5} | {1,-5} | {2,-15} | {3,-25} | {4,-25} | {5,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].Status)
                    Console.WriteLine(configuracaColunasTabela,
                       emprestimo[i].Id, emprestimo[i].Revista.Id, emprestimo[i].Amiguinho.Nome, emprestimo[i].DataEmprestimo.ToString(),
                       emprestimo[i].DataDevolucao.ToString(), emprestimo[i].Status);
            }
            Console.ReadLine();

            if (contador == 0)
            {
                Console.WriteLine("Não existem emprestimos em aberto no momento");
                Console.ReadLine();
            }
        }

        public string ObterOpcoes()
        {
            Console.WriteLine("Digite 1 para registrar um emprestimo");
            Console.WriteLine("Digite 2 para registrar uma devolução");
            Console.WriteLine("Digite 3 para ver emprestimos abertos");
            Console.WriteLine("Digite 4 para ver emprestimos de um determinado mês");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        internal void MostrarEmprestimosPorMes()
        {
            Emprestimo[] emprestimo = controladorEmprestimo.SelecionarTodosEmprestimos();


            Console.WriteLine("Digite o mês que deseja visualizar Ex.'01' : ");
            int mes = Convert.ToInt32(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].DataEmprestimo.Month == mes)
                    count++;
            }

            if (count == 0)
            {
                Console.WriteLine("O mês solicitado, não contém nenhum emprestimo registrado!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nExistem {count} emprestimos neste mês.");

            string configuracaColunasTabela = "{0,-5} | {1,-5} | {2,-15} | {3,-25} | {4,-25} | {5,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].DataEmprestimo.Month == mes)
                    Console.WriteLine(configuracaColunasTabela, emprestimo[i].Id, emprestimo[i].Revista.Id, emprestimo[i].Amiguinho.Id,
                        emprestimo[i].DataEmprestimo.ToString(), emprestimo[i].DataDevolucao.ToString(), emprestimo[i].Status);
            }
            Console.ReadLine();
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Revista", "Amigo", "Emprestimo", "Devolução", "Status");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
