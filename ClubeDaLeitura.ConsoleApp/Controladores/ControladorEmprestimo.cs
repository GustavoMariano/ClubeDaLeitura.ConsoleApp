using ClubeDaLeitura.ConsoleApp.Dominio;
using System;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorEmprestimo : ControladorBase
    {
        private ControladorAmiguinho controladorAmiguinho;
        private ControladorRevista controladorRevista;

        public ControladorEmprestimo(int capacidadeRegistros, ControladorAmiguinho controladorAmiguinho, ControladorRevista controladorRevista) : base(capacidadeRegistros)
        {
            this.controladorAmiguinho = controladorAmiguinho;
            this.controladorRevista = controladorRevista;
        }

        public string RegistrarEmprestimo(int id, int idAmiguinho, int idRevista)
        {
            Emprestimo emprestimo;
            int posicao;

            if(id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo());
                emprestimo = (Emprestimo)registros[posicao];
            }            

            emprestimo.Revista = controladorRevista.SelecionarRevistaPorId(idRevista);
            emprestimo.Amiguinho = controladorAmiguinho.SelecionarAmiguinhoPorId(idAmiguinho);
            emprestimo.DataEmprestimo = DateTime.Now;
            emprestimo.Status = true;

            string resultadoValidacao = emprestimo.Validar();

            if(resultadoValidacao == "EMPRESTIMO_VALIDO")
                registros[posicao] = emprestimo;

            return resultadoValidacao;
        }

        public bool ExcluirEmprestimo(int idSelecionado)
        {
            return ExcluirRegistro(new Emprestimo(idSelecionado));
        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            return (Emprestimo)SelecionarRegistro(new Emprestimo(id));
        }

        public Emprestimo[] SelecionarTodosEmprestimos()
        {
            Emprestimo[] emprestimoAux = new Emprestimo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), emprestimoAux, emprestimoAux.Length);

            return emprestimoAux;
        }

        public bool VerificaEmprestimoRevista(int id)
        {
            Emprestimo[] emprestimo = SelecionarTodosEmprestimos();

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].Revista.Id == id && emprestimo[i].Status)
                    return true;
            }
            return false;
        }

        public bool VerificarEmprestimoAmiguinho(int id)
        {
            Emprestimo[] emprestimo = SelecionarTodosEmprestimos();

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].Amiguinho.Id == id && emprestimo[i].Status)
                    return true;
            }
            return false;
        }

        internal int VerificaId(int idSelecionado)
        {
            Emprestimo[] emprestimos = SelecionarTodosEmprestimos();
            int quantidade = 0;
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i].Id == idSelecionado)
                    quantidade = emprestimos[i].Id;
            }
            return quantidade;
        }
    }
}
