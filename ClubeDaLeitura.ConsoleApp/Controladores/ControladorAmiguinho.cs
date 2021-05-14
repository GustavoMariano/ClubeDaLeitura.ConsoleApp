using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorAmiguinho : ControladorBase
    {
        public ControladorAmiguinho(int capacidadeRegistros) : base(capacidadeRegistros)
        {
        }

        public string RegistrarAmiguinho(int id, string nome, string telefone, string deOndeEh, string responsavel)
        {
            Amiguinho amiguinho;

            int posicao = 0;

            if(id == 0)
            {
                amiguinho = new Amiguinho();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amiguinho(id));
                amiguinho = (Amiguinho)registros[posicao];
            }

            amiguinho.Nome = nome;
            amiguinho.Telefone = telefone;
            amiguinho.DeOndeEh = deOndeEh;
            amiguinho.Responsavel = responsavel;

            string resultadoValidacao = amiguinho.Validar();

            if (resultadoValidacao == "AMIGUINHO_VALIDO")
                registros[posicao] = amiguinho;

            return resultadoValidacao;
        }

        internal int VerificaId(int idSelecionado)
        {
            Amiguinho[] amigo = SelecionarTodosAmiguinhos();
            int quantidade = 0;
            for (int i = 0; i < amigo.Length; i++)
            {
                if (amigo[i].Id == idSelecionado)
                {
                    quantidade = amigo[i].Id;
                }
            }
            return quantidade;
        }

        public bool ExcluirAmiguinho(int idSelecionado)
        {
            return ExcluirRegistro(new Amiguinho(idSelecionado));
        }

        public Amiguinho SelecionarAmiguinhoPorId(int id)
        {
            return (Amiguinho)SelecionarRegistro(new Amiguinho(id));
        }

        public Amiguinho[] SelecionarTodosAmiguinhos()
        {
            Amiguinho[] amiguinhoAux = new Amiguinho[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amiguinhoAux, amiguinhoAux.Length);

            return amiguinhoAux;
        }
    }
}
