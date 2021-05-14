using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Revista
    {
        private int id;
        private string edicao;
        private string colecao;
        private DateTime ano;
        private Caixa caixa;

        public int Id
        {
            get { return this.id; }
        }
        public string Edicao
        {
            get { return this.edicao; }
            set { this.edicao = value; }
        }
        public string Colecao
        {
            get { return this.colecao; }
            set { this.colecao = value; }
        }
        public DateTime Ano

        {
            get { return this.ano; }
            set { this.ano = value; }
        }
        public Caixa Caixa

        {
            get { return this.caixa; }
            set { this.caixa = value; }
        }

        public Revista(int id)
        {
            this.id = id;
        }

        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(edicao))
                resultadoValidacao += "O campo edição é obrigatório \n";

            if (string.IsNullOrEmpty(colecao))
                resultadoValidacao += "O campo Descricao é obrigatório \n";

            if (ano > DateTime.Now)
                resultadoValidacao += "O campo ano não pode ser no futuro \n";

            if (caixa == null)
                resultadoValidacao += "A revista deve estar em alguma caixa \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "REVISTA_VALIDA";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Revista chamadoId = (Revista)obj;

            if (chamadoId != null && chamadoId.id == this.id)
                return true;

            return false;
        }
    }
}
