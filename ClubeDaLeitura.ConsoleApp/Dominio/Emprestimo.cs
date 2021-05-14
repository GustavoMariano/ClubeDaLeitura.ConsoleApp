using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Emprestimo
    {
        private int id;
        private Amiguinho amiguinho;
        private Revista revista;
        private DateTime dataEmprestimo;
        private DateTime dataDevolucao;
        private bool status;

        public int Id
        {
            get { return this.id; }
        }

        public Amiguinho Amiguinho
        {
            get { return this.amiguinho; }
            set { this.amiguinho = value; }
        }

        public Revista Revista
        {
            get { return this.revista; }
            set { this.revista = value; }
        }

        public DateTime DataEmprestimo
        {
            get { return this.dataEmprestimo; }
            set { this.dataEmprestimo = value; }
        }

        public DateTime DataDevolucao
        {
            get { return this.dataDevolucao; }
            set { this.dataDevolucao = value; }
        }

        public bool Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }

        public Emprestimo(int id)
        {
            this.id = id;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (amiguinho == null)
                resultadoValidacao += "O campo amiguinho é obrigatório \n";

            if (revista == null)
                resultadoValidacao += "O campo número é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EMPRESTIMO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Emprestimo emp = (Emprestimo)obj;

            if (id == emp.id)
                return true;
            else
                return false;
        }
    }
}
