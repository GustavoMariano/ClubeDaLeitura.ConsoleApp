using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorRevista : ControladorBase
    {
        private ControladorCaixa controladorCaixa;

        public ControladorRevista(int capacidadeRegistros, ControladorCaixa controlador) : base(capacidadeRegistros)
        {
            this.controladorCaixa = controlador;
        }

        public string RegistrarRevista(int id, int idCaixaSelecionada, string edicao, string colecao, DateTime ano)
        {
            Revista revista;
            int posicao = 0;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

            revista.Caixa = controladorCaixa.SelecionarCaixaPorId(idCaixaSelecionada);
            revista.Edicao = edicao;
            revista.Colecao = colecao;
            revista.Ano = ano;

            string resultadoValidacao = revista.Validar();

            if (resultadoValidacao == "REVISTA_VALIDA")
                registros[posicao] = revista;

            return resultadoValidacao;
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistro(new Revista(id));
        }

        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] revistaAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistaAux, revistaAux.Length);

            return revistaAux;
        }

        internal int VerificaId(int idSelecionado)
        {
            Revista[] revistas = SelecionarTodasRevistas();
            int quantidade = 0;
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i].Id == idSelecionado)
                {
                    quantidade = revistas[i].Id;
                }
            }
            return quantidade;
        }

    }
}
