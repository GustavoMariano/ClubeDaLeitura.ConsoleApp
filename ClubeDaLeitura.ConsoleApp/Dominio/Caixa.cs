using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Caixa
    {
        private int id;
        private string cor;
        private int numero;
        private string etiqueta;

        public int Id
        {
            get { return this.id; }
        }

        public string Cor
        {
            get { return this.cor; }
            set { this.cor = value; }
        }

        public int Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        public string Etiqueta
        {
            get { return this.etiqueta; }
            set { this.etiqueta = value; }
        }

        public Caixa(int id)
        {
            this.id = id;
        }

        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(cor))
                resultadoValidacao += "O campo cor é obrigatório \n";

            if (numero == null)
                resultadoValidacao += "O campo número é obrigatório \n";

            if (string.IsNullOrEmpty(etiqueta))
                resultadoValidacao += "O campo etiqueta é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CAIXA_VALIDA";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Caixa e = (Caixa)obj;

            if (e != null && e.id == this.id)
                return true;

            return false;
        }
    }
}
