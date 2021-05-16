using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorCaixa : ControladorBase
    {
        public ControladorCaixa(int capacidadeRegistros) : base(capacidadeRegistros)
        {
        }

        public string RegistrarCaixa(int id, string cor, int numero, string etiqueta)
        {
            Caixa caixa;
            int posicao = 0;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)registros[posicao];
            }

            caixa.Cor = cor;
            caixa.Numero = numero;
            caixa.Etiqueta = etiqueta;

            string resultadoValidacao = caixa.Validar();

            if (resultadoValidacao == "CAIXA_VALIDA")
                registros[posicao] = caixa;

            return resultadoValidacao; 
        }

        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistro(new Caixa(id));
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] caixaAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), caixaAux, caixaAux.Length);

            return caixaAux;
        }

        internal int VerificaId(int idSelecionado)
        {
            Caixa[] caixa = SelecionarTodasCaixas();
            int quantidade = 0;
            for (int i = 0; i < caixa.Length; i++)
            {
                if (caixa[i].Id == idSelecionado)
                {
                    quantidade = caixa[i].Id;
                }
            }
            return quantidade;
        }
    }
}
