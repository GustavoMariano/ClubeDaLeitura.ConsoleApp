
namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Amiguinho
    {
        private int id;
        private string nome;
        private string telefone;
        private string deOndeEh;
        private string responsavel;

        public int Id
        {
            get { return this.id; }
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public string Telefone
        {
            get { return this.telefone; } 
            set { this.telefone = value; }
        }

        public string DeOndeEh
        {
            get { return this.deOndeEh; }
            set { this.deOndeEh = value; }
        }

        public string Responsavel
        {
            get { return this.responsavel; }
            set { this.responsavel = value; }
        }

        public Amiguinho(int id)
        {
            this.id = id;
        }

        public Amiguinho()
        {
            id = GeradorId.GerarIdAmiguinho();
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo nome é obrigatório \n";

            if (string.IsNullOrEmpty(telefone))
                resultadoValidacao += "O campo telefone é obrigatório \n";

            if (string.IsNullOrEmpty(deOndeEh))
                resultadoValidacao += "O campo de onde é, é obrigatório \n";

            if (string.IsNullOrEmpty(responsavel))
                resultadoValidacao += "O campo responsável é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "AMIGUINHO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Amiguinho amiguinhoId = (Amiguinho)obj;

            if (amiguinhoId != null && amiguinhoId.id == this.id)
                return true;

            return false;
        }
    }
}
